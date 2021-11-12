using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyAPI.Filters;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
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
        private readonly ObjectionService objectionService;
        private readonly IHospitalRegistrationService hospitalRegistrationService;
        private ObjectionMapper mapper = new ObjectionMapper();

        public ObjectionController(ObjectionService objectionService, IHospitalRegistrationService hospitalRegistrationService)
        {
            this.objectionService = objectionService;
            this.hospitalRegistrationService = hospitalRegistrationService;
        }

        [HttpGet]

        public List<Objection> GetAllObjections()
        {
            return objectionService.GetAll();
        }

        [HttpPost]
        public Objection Add(ObjectionDto objection)
        {
            HttpContext.Request.Headers.TryGetValue("ApiKey",out var apiKey);
            Console.WriteLine(apiKey);
            Objection newObjection = mapper.ObjectionDTOToObjection(objection);
            newObjection.HopsitalName = hospitalRegistrationService.GetByApiKey(apiKey).Name;
            return objectionService.Add(newObjection);
        }

    }
}
