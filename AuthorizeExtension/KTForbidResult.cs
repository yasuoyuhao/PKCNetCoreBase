using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.AuthorizeExtension
{
    public class KTForbidResult : JsonResult
    {
        public KTForbidResult(): base(new KTForbidResultData())
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }

    public class KTForbidResultData
    {
        public readonly bool success = false;
        public readonly int code = StatusCodes.Status403Forbidden;
        public readonly string message = "Authorization Rejection";

    }
}
