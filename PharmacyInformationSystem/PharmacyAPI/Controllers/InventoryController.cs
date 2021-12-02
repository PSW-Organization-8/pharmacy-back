using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyAPI.Filters;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController
    {
        private readonly IPharmacyService pharmacyService;
        private readonly IInventoryLogService inventoryLogService;
        private readonly IMedicationService medicationService;

        public InventoryController(IPharmacyService pharmacyService, IInventoryLogService inventoryLogService, IMedicationService medicationService)
        {
            this.pharmacyService = pharmacyService;
            this.inventoryLogService = inventoryLogService;
            this.medicationService = medicationService;
        }

        [HttpPut]
        [Route("append_medication")]
        public bool AppendMedication(InventoryManagementDto dto)
        {
            return inventoryLogService.AddMedication(dto.PhamracyID, dto.MedicationID, dto.Quantity);
        }

        [HttpPut]
        [Route("remove_medication")]
        public bool RemoveMedication(InventoryManagementDto dto)
        {
            return inventoryLogService.RemoveMedication(dto.PhamracyID, dto.MedicationID, dto.Quantity);
        }

        [HttpGet]
        public List<PharmacyWithInventoryDTO> CheckQuantity(string name, int quantity) 
        {
            List<Medication> medications = medicationService.Search(name, new List<string>());
            List<Pharmacy> allPharmacies = pharmacyService.GetAll();
            List<PharmacyWithInventoryDTO> retVal = new List<PharmacyWithInventoryDTO>();
            foreach (Pharmacy p in allPharmacies) {
                DataForMapperDTO dataForMapper = new DataForMapperDTO(medications, p, inventoryLogService.GetLogsByPharmacyWithQuantity(p.Id, quantity));
                PharmacyWithInventoryDTO pharmacyWithInventory = PharmacyWithInventoryMapper.PharmacyAndInventoryToPharmacyWithInventory(dataForMapper);
                if (pharmacyWithInventory != null) {
                    retVal.Add(pharmacyWithInventory);
                }
            }
            return retVal;
        }

        [HttpGet]
        [Route("medication_exists")]
        public bool CheckIfMedicationExists(string name, int quantity)
        {
            return inventoryLogService.CheckIfQuantityExists(name, quantity);
        }
    }
}
