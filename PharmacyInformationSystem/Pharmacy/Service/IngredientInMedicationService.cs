using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.IngredientMedicationRepository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class IngredientInMedicationService : IIngredientInMedicationService
    {
        private readonly IIngredientsInMediactionRepository repository;
        private readonly IMedicationRepository medicationRepository;
        private readonly IMedicationIngredientRepository ingredientRepository;

        public IngredientInMedicationService(IIngredientsInMediactionRepository repository, IMedicationRepository medicationRepository, IMedicationIngredientRepository ingredientRepository)
        {
            this.repository = repository;
            this.medicationRepository = medicationRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public List<MedicationIngredient> GetIngredientByMedication(long id)
        {
            List<MedicationIngredient> ingredients = new List<MedicationIngredient>();
            foreach (IngredientInMediaction entity in repository.GetAll())
            {
                if (entity.MedicationID == id)
                {
                    ingredients.Add(ingredientRepository.Get(entity.IngredientID));
                }
            }
            return ingredients;
        }

        public List<Medication> GetMedicationByIngredient(long id)
        {
            List<Medication> medication = new List<Medication>();
            foreach (IngredientInMediaction entity in repository.GetAll())
            {
                if (entity.IngredientID == id)
                {
                    medication.Add(medicationRepository.Get(entity.MedicationID));
                }
            }
            return medication;
        }

        public void RemoveIngredientReferences(long id)
        {
            foreach (IngredientInMediaction entity in repository.GetAll())
            {
                if (entity.IngredientID == id)
                {
                    repository.Delete(entity.Id);
                }
            }
        }

        public void RemoveMedicineReferences(long id)
        {
            foreach (IngredientInMediaction entity in repository.GetAll())
            {
                if (entity.MedicationID == id)
                {
                    repository.Delete(entity.Id);
                }
            }
        }
    }
}
