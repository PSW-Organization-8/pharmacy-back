using Grpc.Core;
using PharmacyAPI.Dto;
using PharmacyAPI.Filters;
using PharmacyAPI.Mapper;
using PharmacyAPI.Protos;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    public class MedicationGrpcController : MedicationGrpcService.MedicationGrpcServiceBase
    {
        private readonly IPharmacyService pharmacyService;
        private readonly IInventoryLogService inventoryLogService;
        private readonly IMedicationService medicationService;
        private readonly GrpcApiKeyFilter grpcApiKeyFilter;
        private readonly EmailService emailService;

        public MedicationGrpcController()
        {
        }

        public MedicationGrpcController(IPharmacyService pharmacyService, IInventoryLogService inventoryLogService,
            IMedicationService medicationService, GrpcApiKeyFilter grpcApiKeyFilter, EmailService emailService)
        {
            this.pharmacyService = pharmacyService;
            this.inventoryLogService = inventoryLogService;
            this.medicationService = medicationService;
            this.grpcApiKeyFilter = grpcApiKeyFilter;
            this.emailService = emailService;
        }

        public override Task<CheckMedicationAvailabilityResponseProto> CheckMedicationQuantity(
            CheckMedicationAvailabilityProto request, ServerCallContext context)
        {
            CheckMedicationAvailabilityResponseProto response = new CheckMedicationAvailabilityResponseProto();
            if (grpcApiKeyFilter.ApiKeyIsOk(request.ApiKey))
            {
                List<Medication> medications = medicationService.Search(request.Name, new List<string>());
                List<Pharmacy> allPharmacies = pharmacyService.GetAll();

                foreach (Pharmacy p in allPharmacies)
                {
                    DataForMapperDTO dataForMapper = new DataForMapperDTO(medications, p,
                        inventoryLogService.GetLogsByPharmacyWithQuantity(p.Id, request.Quantity));
                    MedicationAvailabilityProto pharmacyWithInventory =
                        PharmacyWithInventoryMapper.PharmacyAndInventoryToPharmacyWithInventoryGrpc(dataForMapper);
                    if (pharmacyWithInventory != null)
                    {
                        response.MedicationAvailability.Add(pharmacyWithInventory);
                    }
                }
            }

            return Task.FromResult(response);
        }

        public override Task<OrderResponseProto> OrderMedication(OrderProto order, ServerCallContext context)
        {
            OrderResponseProto response = new OrderResponseProto();
            if (grpcApiKeyFilter.ApiKeyIsOk(order.ApiKey))
            {
                response.Response =
                    inventoryLogService.RemoveMedication(order.PharmacyID, order.MedicationID, order.Quantity);
                emailService.EmailHospitalThatMedicinesDelivered("Apoteka2", order.ApiKey, order.PharmacyID, order.MedicationID, order.Quantity);
            }
            else

            {
                response.Response = false;
            }

            return Task.FromResult(response);
        }

        public override Task<OrderResponseProto> ReturnMedication(OrderProto order, ServerCallContext context)
        {
            OrderResponseProto response = new OrderResponseProto();
            if (grpcApiKeyFilter.ApiKeyIsOk(order.ApiKey))
                response.Response =
                    inventoryLogService.AddMedication(order.PharmacyID, order.MedicationID, order.Quantity);
            else
            {
                response.Response = false;
            }

            return Task.FromResult(response);
        }
    }
}