using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Repository.RegistratedHospitalRepository
{
    public interface IRegisteredHospitalRepository : IGenericRepository<RegisteredHospital, string>
    {
        bool ExistsByApiKey(string apiKey);
    }
}
