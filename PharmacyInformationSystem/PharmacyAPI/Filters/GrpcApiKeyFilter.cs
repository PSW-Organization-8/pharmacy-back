using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using System;

namespace PharmacyAPI.Filters
{
    public class GrpcApiKeyFilter
    {
        private IRegisteredHospitalRepository registeredHospitalRepository;

        public GrpcApiKeyFilter(IRegisteredHospitalRepository registeredHospitalRepository1)
        {
            registeredHospitalRepository = registeredHospitalRepository1;
        }

        public bool ApiKeyIsOk(String ApiKey)
        {
            if (!registeredHospitalRepository.ExistsByApiKey(ApiKey))
            {
                return false;
            }
            return true;
        }
    }
}
