using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService responseService;
        private readonly IHospitalRegistrationService hospitalRegistrationService;

        public ResponseController(IResponseService responseService, IHospitalRegistrationService hospitalRegistrationService) {

            this.responseService = responseService;
            this.hospitalRegistrationService = hospitalRegistrationService;
        }

        [HttpPost]
        public Response Add(ObjectionWithResponseDto objectionWithResponse)
        {
            Response newResponse = new Response(objectionWithResponse.Id, objectionWithResponse.TextResponse, objectionWithResponse.HospitalName);
            ResponseDto responseDto = new ResponseDto(objectionWithResponse.TextResponse, objectionWithResponse.Id.ToString());
            RegisteredHospital registeredHospital = hospitalRegistrationService.GetByName(objectionWithResponse.HospitalName);
            RestClient restClient = new RestClient(registeredHospital.Url + "/api/Response");
            RestRequest request = new RestRequest();
            request.AddJsonBody(responseDto);
            request.AddHeader("ApiKey", registeredHospital.ApiKey);
            restClient.Post(request);
            return responseService.Add(newResponse);
        }
    }
}
