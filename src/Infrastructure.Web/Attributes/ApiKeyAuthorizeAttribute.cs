using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Web.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Infrastructure.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var apiCredential = context.HttpContext.Items["ApiCredential"];

            if (apiCredential == null)
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(new ApiResult("unauthorized", "Unauthorized")),
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status401Unauthorized
                };
        }
    }
}
