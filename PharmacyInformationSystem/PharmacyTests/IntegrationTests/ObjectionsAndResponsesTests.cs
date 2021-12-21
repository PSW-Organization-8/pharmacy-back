using PharmacyAPI.Controllers;
using PharmacyAPI.Dto;
using PharmacyClassLib;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.ObjectionRepository;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;
using PharmacyClassLib.Repository.ResponseRepository;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyTests.IntegrationTests
{
    public class ObjectionsAndResponsesTests
    {
        [Fact]
        public void Objections_with_responses_exist()
        {
           ObjectionController controller = GetObjectionController();

            List<ObjectionWithResponseDto> retVal = controller.GetAllObjections();

            retVal.ShouldNotBeNull();
        }

        private ObjectionController GetObjectionController()
        {
            MyDbContext dbContext = new MyDbContext();
            IObjectionRepository objectionRepository = new ObjectionRepository(dbContext);
            IResponseRepository responseRepository = new ResponseRepository(dbContext);
            IRegisteredHospitalRepository registeredHospitalRepository = new RegisteredHospitalRepository(dbContext);
            IChannelsForCommunication channelsForCommunication = new RabbitMQChannelsForCommunication(registeredHospitalRepository);
            IObjectionService objectionService = new ObjectionService(objectionRepository);
            IResponseService responseService = new ResponseService(responseRepository);
            IHospitalRegistrationService hospitalRegistrationService = new HospitalRegistrationService(registeredHospitalRepository, channelsForCommunication);
            ObjectionController controller = new ObjectionController(objectionService, hospitalRegistrationService, responseService);
            return controller;
        }
    }
}
