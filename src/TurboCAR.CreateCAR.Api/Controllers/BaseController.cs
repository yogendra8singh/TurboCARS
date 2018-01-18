using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Api.Results;

namespace TurboCAR.CreateCAR.Api.Controllers
{
    public class BaseController : Controller
    {
        protected HttpObjectResponse ObjectResponse(int httpStatusCode, object responseBody)
        {
            return new HttpObjectResponse(httpStatusCode, responseBody);
        }

    }
}
