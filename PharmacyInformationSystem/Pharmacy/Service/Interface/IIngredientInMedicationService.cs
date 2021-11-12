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
    }
}
