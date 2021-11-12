using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            this.medicationRepository = medicationRepository;
        }

        public Medication Create(Medication newMedication)
        {
            return medicationRepository.Create(newMedication);
        }

        public bool Delete(long id)
        {
            bool success = false;
            if (Get(id) != null)
            {
                success = true;
                medicationRepository.Delete(id);
            }
            return success;
        }

        public Medication Get(long id)
        {
            return medicationRepository.Get(id);
        }

        public List<Medication> GetAll()
        {
            return medicationRepository.GetAll();
        }
    }
}
