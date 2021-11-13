using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : Controller
    {
        private readonly IMedicationIngredientService ingredientService;
        private readonly IIngredientInMedicationService ingredientInMedicationService;

        public IngredientController(IMedicationIngredientService ingredientService, IIngredientInMedicationService ingredientInMedicationService)
        {
            this.ingredientService = ingredientService;
            this.ingredientInMedicationService = ingredientInMedicationService;
        }

        [HttpPost]
        public MedicationIngredient Create([FromBody]IngredientDto dto)
        {
            return ingredientService.Create(dto.Name);
        }

        [HttpDelete("{id?}")]
        public void Delete(long id)
        {
            ingredientService.Delete(id);
        }

        [HttpPut]
        [Route("append_ingredients")]
        public void AppendIngredients([FromBody] IngredientDto dto)
        {
            ingredientInMedicationService.AddIngredients(dto.Id, dto.Ids);
        }

        [HttpPut]
        [Route("remove_ingredients")]
        public void RemoveIngredients([FromBody] IngredientDto dto)
        {
            ingredientInMedicationService.RemoveIngredients(dto.Id, dto.Ids);
        }
    }
}
