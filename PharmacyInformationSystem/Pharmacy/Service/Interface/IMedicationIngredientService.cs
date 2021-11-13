using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public interface IMedicationIngredientService
    {
        List<MedicationIngredient> GetAll();

        MedicationIngredient Get(long id);

        MedicationIngredient Create(string name);

        void Delete(long id);

    }
}
