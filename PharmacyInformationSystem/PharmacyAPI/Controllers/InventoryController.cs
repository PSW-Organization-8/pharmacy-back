using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController
    {
        private readonly IPharmacyService pharmacyService;
        private readonly IInventoryLogService inventoryLogService;

        public InventoryController(IPharmacyService pharmacyService, IInventoryLogService inventoryLogService)
        {
            this.pharmacyService = pharmacyService;
            this.inventoryLogService = inventoryLogService;
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
    }
}
