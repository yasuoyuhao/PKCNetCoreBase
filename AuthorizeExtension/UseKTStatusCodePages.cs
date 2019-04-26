using Base.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.AuthorizeExtension
{
    public static class UseKTStatusCodePagesExtension
    {
        public static void UseKTStatusCodePages(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Request.Path.StartsWithSegments("/api") &&
                   (context.HttpContext.Response.StatusCode == StatusCodes.Status403Forbidden))
                {
                    var resp = new ResponseResult<string>(ResponseCode.forbidden, "Authorization Rejection", $"{ StatusCodes.Status403Forbidden } Insufficient Permissions").ResponseResultMaker();

                    context.HttpContext.Response.ContentType = "application/json";

                    var serializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(resp, serializerSettings));
                }
            });
        }
    }
}
