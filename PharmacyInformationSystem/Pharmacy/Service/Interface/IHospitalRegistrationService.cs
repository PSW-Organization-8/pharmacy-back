using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service
{
    public interface IHospitalRegistrationService
    {
        public RegisteredHospital Get(string hospitalName);
        public RegisteredHospital Register(RegisteredHospital newHospital);
        public RegisteredHospital GetByApiKey(string apyKey);
    }
}
