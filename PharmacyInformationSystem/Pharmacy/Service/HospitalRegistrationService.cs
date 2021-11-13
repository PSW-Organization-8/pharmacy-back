using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;

namespace PharmacyClassLib.Service
{
    public class HospitalRegistrationService : IHospitalRegistrationService
    {
        private readonly IRegisteredHospitalRepository regHospitalRepository;

        public HospitalRegistrationService(IRegisteredHospitalRepository regHospitalRepository)
        {
            this.regHospitalRepository = regHospitalRepository;
        }

        public RegisteredHospital Get(string hospitalName)
        {
            return regHospitalRepository.Get(hospitalName);
        }

        public RegisteredHospital GetByApiKey(string apyKey)
        {
            List<RegisteredHospital> hospitals = regHospitalRepository.GetAll();
            foreach (RegisteredHospital hospital in hospitals) {
                if (hospital.ApiKey.Equals(apyKey)) {
                    return hospital;
                }
            }
            return null;
        }

        public RegisteredHospital Register(RegisteredHospital newHospital)
        {
            newHospital.ApiKey = Guid.NewGuid().ToString();
            return regHospitalRepository.Create(newHospital);
        }
    }

}
