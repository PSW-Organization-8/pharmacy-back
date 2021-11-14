using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public interface IIngredientInMedicationService
    {
        List<Medication> GetMedicationByIngredient(long id);

        List<MedicationIngredient> GetIngredientByMedication(long id);

        void RemoveMedicineReferences(long id);

        void RemoveIngredientReferences(long id);

        void AddIngredients(long medicationId, List<long> ids);

        void RemoveIngredients(long medicationId, List<long> ids);

    }
}
