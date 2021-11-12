using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public interface IMedicationService
    {
        List<Medication> GetAll();

        List<Medication> Search(string text, List<string> ingredients);

        Medication Get(long id);

        Medication Create(Medication newMedication);

        Boolean Delete(long id);

        Boolean Update(Medication medication);


    }
}
