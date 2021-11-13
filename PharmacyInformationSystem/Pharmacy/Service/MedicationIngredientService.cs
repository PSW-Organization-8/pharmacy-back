using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationIngredientService : IMedicationIngredientService

    {
        private readonly IMedicationIngredientRepository ingredientRepository;
        private readonly IIngredientInMedicationService ingredientInMedicationService;

        public MedicationIngredientService(IMedicationIngredientRepository ingredientRepository, IIngredientInMedicationService ingredientInMedicationService)
        {
            this.ingredientRepository = ingredientRepository;
            this.ingredientInMedicationService = ingredientInMedicationService;
        }

        public MedicationIngredient Create(string name)
        {
            return ingredientRepository.Create(new MedicationIngredient(0, name));
        }

        public void Delete(long id)
        {
            ingredientInMedicationService.RemoveIngredientReferences(id);
            ingredientRepository.Delete(id);
        }

        public MedicationIngredient Get(long id)
        {
            return ingredientRepository.Get(id);
        }

        public List<MedicationIngredient> GetAll()
        {
            return ingredientRepository.GetAll();
        }

    }
}
