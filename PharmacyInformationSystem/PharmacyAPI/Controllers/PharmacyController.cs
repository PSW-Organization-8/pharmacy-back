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

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService pharmacyService;
        private readonly IInventoryLogService inventoryLogService;

        public PharmacyController(IPharmacyService pharmacyService, IInventoryLogService inventoryLogService)
        {
            this.pharmacyService = pharmacyService;
            this.inventoryLogService = inventoryLogService;
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


    }
}
