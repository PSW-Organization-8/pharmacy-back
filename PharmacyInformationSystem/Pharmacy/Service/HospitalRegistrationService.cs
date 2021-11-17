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
        private readonly ISendingNewsService sendingNewsService;

        public HospitalRegistrationService(IRegisteredHospitalRepository regHospitalRepository, ISendingNewsService sendingNewsService)
        {
            this.regHospitalRepository = regHospitalRepository;
            this.sendingNewsService = sendingNewsService;
        }

        public RegisteredHospital Get(string hospitalName)
        {
            return regHospitalRepository.Get(hospitalName);
        }

        public RegisteredHospital GetByApiKey(string apyKey)
        {
            List<RegisteredHospital> hospitals = regHospitalRepository.GetAll();
            foreach (RegisteredHospital hospital in hospitals)
            {
                if (hospital.ApiKey.Equals(apyKey))
                {
                    return hospital;
                }
            }
            return null;
        }

        public RegisteredHospital Register(RegisteredHospital newHospital)
        {
            newHospital.ApiKey = Guid.NewGuid().ToString();
            sendingNewsService.CreateChannel(newHospital);
            return regHospitalRepository.Create(newHospital);
        }
    }

}
