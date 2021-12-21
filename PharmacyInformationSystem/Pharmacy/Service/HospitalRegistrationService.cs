using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Service.Interface;

namespace PharmacyClassLib.Service
{
    public class HospitalRegistrationService : IHospitalRegistrationService
    {
        private readonly IRegisteredHospitalRepository regHospitalRepository;
        private readonly IChannelsForCommunication channelsForCommunication;

        public HospitalRegistrationService(IRegisteredHospitalRepository regHospitalRepository, IChannelsForCommunication channelsForCommunication)
        {
            this.regHospitalRepository = regHospitalRepository;
            this.channelsForCommunication = channelsForCommunication;
        }

        public RegisteredHospital Get(string hospitalName)
        {
            return regHospitalRepository.Get(hospitalName);
        }

        public RegisteredHospital GetByApiKey(string apyKey)
        {
            return regHospitalRepository.GetByApiKey(apyKey);
        }

        public RegisteredHospital GetByName(string name)
        {
            return regHospitalRepository.GetByName(name);
        }

        public RegisteredHospital Register(RegisteredHospital newHospital)
        {
            newHospital.ApiKey = Guid.NewGuid().ToString();
            channelsForCommunication.CreateChannelsForHospital(newHospital);
            return regHospitalRepository.Create(newHospital);
        }
    }

}
