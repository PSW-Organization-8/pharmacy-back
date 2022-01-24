using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Filters;
using PharmacyClassLib.Service.Interface;
using PharmacyAPI.Dto;
using PharmacyClassLib.Model.Commercials;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService pharmacyService;
        private readonly IInventoryLogService inventoryLogService;
        private readonly IMedicationPromotionService medicationPromotionService;

        public PharmacyController(IPharmacyService pharmacyService, IInventoryLogService inventoryLogService, IMedicationPromotionService medicationPromotionService)
        {
            this.pharmacyService = pharmacyService;
            this.inventoryLogService = inventoryLogService;
            this.medicationPromotionService = medicationPromotionService;
        }

        [HttpGet]
        public List<Pharmacy> GetAllPharmacies()
        {
            return pharmacyService.GetAll();
        }

        [HttpGet]
        [Route("medication/{id?}")]
        public List<InventoryItem> GetMedicationByPharmacy(long id)
        {
            return inventoryLogService.GetPharmacyInventory(id);
        }

        [HttpGet]
        [Route("receiveMessage")]
        public IActionResult ReceiveMessages()
        {
            TenderCommunicationRabbitMQ tenderCommunication = new TenderCommunicationRabbitMQ();
            
            return Ok(tenderCommunication.ReceiveNewTenders());
        }

        [HttpGet]
        [Route("promotions")]
        public IActionResult GetMedicationPromotions()
        {
            return Ok(medicationPromotionService.Get());
        }
    }
}
