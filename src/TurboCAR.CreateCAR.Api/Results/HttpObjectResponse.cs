using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurboCAR.CreateCAR.Api.Results
{
    public class HttpObjectResponse : ObjectResult
    {
        public HttpObjectResponse(int httpStatusCode, object responseBody) : base(responseBody)
        {
            StatusCode = httpStatusCode;
        }
    }

    public class HttpResponseContent
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class CARCreationResult : HttpResponseContent
    {
        public string CARId { get; set; }

    }
}
