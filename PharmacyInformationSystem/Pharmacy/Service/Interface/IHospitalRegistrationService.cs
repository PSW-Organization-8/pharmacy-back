using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service
{
    public interface IHospitalRegistrationService
    {
        RegisteredHospital Get(string hospitalName);
        RegisteredHospital Register(RegisteredHospital newHospital);
        RegisteredHospital GetByApiKey(string apyKey);
    }
}
