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
        private readonly IIngredientsInMedicationRepository repository;
        private readonly IMedicationRepository medicationRepository;
        private readonly IMedicationIngredientRepository ingredientRepository;

        public IngredientInMedicationService(IIngredientsInMedicationRepository repository, IMedicationRepository medicationRepository, IMedicationIngredientRepository ingredientRepository)
        {
            this.repository = repository;
            this.medicationRepository = medicationRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public void AddIngredients(long medicationId, List<long> ids)
        {
            if (medicationRepository.Get(medicationId)!= null)
            {
                foreach(long id in ids)
                {
                    IngredientInMedication ingredient = IngredientInMedication(GetListByMedication(medicationId), id);
                    if (ingredient == null && ingredientRepository.Get(id) != null)
                    {
                        ingredient = new IngredientInMedication(0, medicationId, id);
                        repository.Create(ingredient);
                    }
                }

            }
        }

        private static IngredientInMedication IngredientInMedication(List<IngredientInMedication> list, long id)
        {
            IngredientInMedication ingredient = null;
            foreach (IngredientInMedication entity in list)
            {
                if (entity.IngredientID == id)
                {
                    ingredient = entity;
                    break;
                }
            }
            return ingredient;
        }

        private List<IngredientInMedication> GetListByMedication(long medicationId)
        {
            List<IngredientInMedication> listByMedication = new List<IngredientInMedication>();
            foreach (IngredientInMedication entity in repository.GetAll())
            {
                if (entity.MedicationID == medicationId)
                {
                    listByMedication.Add(entity);
                }
            }
            return listByMedication;
        }

        public List<MedicationIngredient> GetIngredientByMedication(long id)
        {
            List<MedicationIngredient> ingredients = new List<MedicationIngredient>();
            foreach (IngredientInMedication entity in repository.GetAll())
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
            foreach (IngredientInMedication entity in repository.GetAll())
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
            foreach (IngredientInMedication entity in repository.GetAll())
            {
                if (entity.IngredientID == id)
                {
                    repository.Delete(entity.Id);
                }
            }
        }

        public void RemoveIngredients(long medicationId, List<long> ids)
        {
            if (medicationRepository.Get(medicationId) != null)
            {
                foreach (long id in ids)
                {
                    IngredientInMedication ingredient = IngredientInMedication(GetListByMedication(medicationId), id);
                    if (ingredient != null)
                    {
                        repository.Delete(ingredient.Id);
                    }
                }
            }
        }

        public void RemoveMedicineReferences(long id)
        {
            foreach (IngredientInMedication entity in repository.GetAll())
            {
                if (entity.MedicationID == id)
                {
                    repository.Delete(entity.Id);
                }
            }
        }
    }
}
