using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PharmacyClassLib.Repository.RegistratedHospitalRepository;

namespace PharmacyAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var receivedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var regHospitalRepository = context.HttpContext.RequestServices.GetService<IRegisteredHospitalRepository>();
            if (!regHospitalRepository.ExistsByApiKey(receivedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
