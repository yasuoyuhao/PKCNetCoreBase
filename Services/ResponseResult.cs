using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services
{
    public class ResponseResult<T>
    {
        public readonly bool Success = false;
        public readonly int Code = (int)ResponseCode.ok;
        public readonly string Message = "";
        public readonly T Content;

        public ResponseResult(ResponseCode code, string message, T content)
        {
            Success = code == ResponseCode.ok;
            Code = (int)code;
            Message = message;
            Content = content;
        }

        public object ResponseResultMaker()
        {
            return new
            {
                success = Success,
                code = Code,
                message = Message,
                content = Content
            };
        }

        public object ResponseResultMakerFromToken()
        {
            return new
            {
                success = Success,
                code = Code,
                message = Message,
                token = Content
            };
        }
    }

    public enum ResponseCode
    {
        ok = 200,
        connectSccessButDataProcessingIsWrong = 201,
        connectSccessButAuthorizationFailure = 202,
        workhasbeensuccessfulqueue = 250,
        unauthorized = 401,
        forbidden = 403
    }
}
