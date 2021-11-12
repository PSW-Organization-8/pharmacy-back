using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;

namespace PharmacyClassLib.Service
{
    public class HospitalRegistrationService : IHospitalRegistrationService
    {
        private readonly IRegistratedHospitalRepository regHospitalRepository;

        public HospitalRegistrationService(IRegistratedHospitalRepository regHospitalRepository)
        {
            this.regHospitalRepository = regHospitalRepository;
        }

        public RegistratedHospital Get(string hospitalName)
        {
            return regHospitalRepository.Get(hospitalName);
        }

        public RegistratedHospital GetByApiKey(string apyKey)
        {
            List<RegistratedHospital> hospitals = regHospitalRepository.GetAll();
            foreach (RegistratedHospital hospital in hospitals) {
                if (hospital.ApiKey.Equals(apyKey)) {
                    return hospital;
                }
            }
            return null;
        }

        public RegistratedHospital Register(RegistratedHospital newHospital)
        {
            newHospital.ApiKey = Guid.NewGuid().ToString();
            return regHospitalRepository.Create(newHospital);
        }
    }

}
