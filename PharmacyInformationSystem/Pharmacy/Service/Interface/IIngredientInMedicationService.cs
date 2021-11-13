using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public interface IIngredientInMedicationService
    {
        public List<Medication> GetMedicationByIngredient(long id);

        public List<MedicationIngredient> GetIngredientByMedication(long id);

        public void RemoveMedicineReferences(long id);

        public void RemoveIngredientReferences(long id);

        public void AddIngredients(long medicationId, List<long> ids);

        public void RemoveIngredients(long medicationId, List<long> ids);

    }
}
