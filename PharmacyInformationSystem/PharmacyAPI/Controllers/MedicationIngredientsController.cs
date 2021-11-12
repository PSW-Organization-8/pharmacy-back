using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Filters;
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
    public class MedicationIngredientsController
    {

        private readonly IMedicationIngredientService medicationIngredientService;

        public MedicationIngredientsController(IMedicationIngredientService medicationIngredientService)
        {
            this.medicationIngredientService = medicationIngredientService;
        }

        [HttpGet]
        public List<MedicationIngredient> GetAll()
        {
            return medicationIngredientService.GetAll();
        }

        [HttpGet("{id?}")]
        public MedicationIngredient Get(long id)
        {
            return medicationIngredientService.Get(id);
        }
    }

}
