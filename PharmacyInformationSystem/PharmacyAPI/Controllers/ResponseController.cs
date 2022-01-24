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
        public IActionResult Add(ObjectionWithResponseDto objectionWithResponse)
        {
            Response newResponse = new Response(objectionWithResponse.Id, objectionWithResponse.TextResponse, objectionWithResponse.HospitalName);
            Response savedResponse = responseService.Add(newResponse);
            if (savedResponse == null) return StatusCode(500, "Error! Response not recorded!");
            ResponseDto responseDto = new ResponseDto(objectionWithResponse.TextResponse, objectionWithResponse.Id.ToString());
            RegisteredHospital registeredHospital = hospitalRegistrationService.GetByName(objectionWithResponse.HospitalName);
            RestClient restClient = new RestClient(registeredHospital.Url + "/api/Response");
            RestRequest request = new RestRequest();
            request.AddJsonBody(responseDto);
            request.AddHeader("ApiKey", registeredHospital.ApiKey);
            var data = restClient.Post<IActionResult>(request);
            if (data.StatusCode != System.Net.HttpStatusCode.OK) return StatusCode(502, "Error! Response not sent to hospital!");
            return Ok();

        }
    }
}
