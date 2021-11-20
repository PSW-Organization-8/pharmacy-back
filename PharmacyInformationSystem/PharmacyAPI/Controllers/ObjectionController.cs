using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyAPI.Filters;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionController : ControllerBase
    {
        private readonly IObjectionService objectionService;
        private readonly IHospitalRegistrationService hospitalRegistrationService;
        private readonly IResponseService responseService;
        private ObjectionMapper mapper = new ObjectionMapper();

        public ObjectionController(IObjectionService objectionService, IHospitalRegistrationService hospitalRegistrationService, IResponseService responseService)
        {
            this.objectionService = objectionService;
            this.hospitalRegistrationService = hospitalRegistrationService;
            this.responseService = responseService;
        }

        [HttpGet]

        public List<ObjectionWithResponseDto> GetAllObjections()
        {
            List<ObjectionWithResponseDto> retVal = new List<ObjectionWithResponseDto>();
            foreach (Objection objection in objectionService.GetAll())
            {
                Response response = responseService.GetResponseByObjectionId(objection.ObjectionIdFromHospitalDatabase, objection.HopsitalName);
                ObjectionWithResponseDto objectionWithResponse = new ObjectionWithResponseDto(objection.ObjectionIdFromHospitalDatabase, objection.HopsitalName, objection.TextObjection, response.TextResponse);
                retVal.Add(objectionWithResponse);
            }
            return retVal;
        }

        [HttpPost]
        public Objection Add(ObjectionDto objection)
        {
            HttpContext.Request.Headers.TryGetValue("ApiKey",out var apiKey);
            Objection newObjection = mapper.ObjectionDTOToObjection(objection);
            newObjection.HopsitalName = hospitalRegistrationService.GetByApiKey(apiKey).Name;
            return objectionService.Add(newObjection);
        }

    }
}
