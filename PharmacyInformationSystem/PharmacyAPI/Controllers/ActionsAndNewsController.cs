using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Dto;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service.Interface;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api/actionsAndNews")]
    public class ActionsAndNewsController : ControllerBase
    {
        private readonly IActionsAndNewsService actionsAndNewsService;

        public ActionsAndNewsController(IActionsAndNewsService actionsAndNewsService)
        {
            this.actionsAndNewsService = actionsAndNewsService;
        }

        [HttpPost]
        public News CreateAndSendNewsToAllSubscribedHospitals(NewsDto newsDto)
        {
            return actionsAndNewsService.CreateAndSendNewsToAllSubscribedHospitals(NewsMapper.NewsDtoToNews(newsDto));
        }
    }
}
