

using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Filters;
using PharmacyAPI.Dto;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Service.Interface;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController
    {

        private readonly IMedicationService medicationService;
        private readonly IInventoryLogService inventoryLogService;

        public MedicationController(IMedicationService medicationService, IInventoryLogService inventoryLogService)
        {
            this.medicationService = medicationService;
            this.inventoryLogService = inventoryLogService;
        }

        [HttpGet]
        public List<Medication> GetAll()
        {
            return medicationService.GetAll();
        }

        [HttpGet("{id?}")]
        public Medication Get(long id)
        {
            return medicationService.Get(id);
        }

        [HttpDelete("{id?}")]
        public bool Delete(long id)
        {
            return medicationService.Delete(id);
        }

        [HttpPost]
        public Medication Create(MedicationDto dto)
        {
            return medicationService.Create(
                MedicationMapper.DtoToMedication(dto));
        }

        [HttpPut]
        public bool Update([FromBody]MedicationDto dto)
        {
            return medicationService.Update(MedicationMapper.DtoToMedication(dto));
        }

        [HttpGet]
        [Route("search")]
        public List<Medication> Search([FromBody]MedicationSearchFilterDto searchFilterDto)
        {
            return medicationService.Search(searchFilterDto.Text, searchFilterDto.Ingredients);
        }


        [HttpGet]
        [Route("distribution/{id?}")]
        public List<MedicationDistribution> GetMedicationDistribution(long id)
        {
            return inventoryLogService.GetMedicationDistribution(id);
        }

    }

}
