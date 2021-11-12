using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service
{
    public interface IHospitalRegistrationService
    {
        public RegistratedHospital Get(string hospitalName);
        public RegistratedHospital Register(RegistratedHospital newHospital);
        public RegistratedHospital GetByApiKey(string apyKey);
    }
}
