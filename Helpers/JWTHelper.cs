using Base.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Base.Helpers
{
    public static class JWTHelper
    {
        public static JwtBearerEvents KTJwtBearerEvents()
        {
            return new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                 {
                     string err = "";

                     var exType = context.Exception.GetType();

                     if (exType == typeof(SecurityTokenValidationException))
                     {
                         err += "invalid token";
                     }
                     else if (exType == typeof(SecurityTokenInvalidIssuerException))
                     {
                         err += "invalid issuer";
                     }
                     else if (exType == typeof(SecurityTokenExpiredException))
                     {
                         err += "token expired";
                     }
                     else if (exType == typeof(SecurityTokenKeyWrapException))
                     {
                         err += "token key fail";
                     }
                     else if (exType == typeof(SecurityTokenInvalidSignatureException))
                     {
                         err += "token key invalid signature";
                     }

                     context.Response.ContentType = "application/json";
                     context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                     var resp = new ResponseResult<string>(ResponseCode.unauthorized, "Authorization Rejection", $"{ err }").ResponseResultMaker();

                     context.Response.WriteAsync(JsonConvert.SerializeObject(resp, Formatting.Indented)).Wait();

                     return Task.CompletedTask;
                 },

                OnChallenge = context =>
                {
                    if (context.AuthenticateFailure == null)
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                        var resp = new ResponseResult<string>(ResponseCode.unauthorized, "Authorization Rejection", $"token is not find").ResponseResultMaker();

                        context.Response.WriteAsync(JsonConvert.SerializeObject(resp, Formatting.Indented)).Wait();
                    }

                    context.HandleResponse();
                    return Task.CompletedTask;
                }
            };
        }
    }
}
