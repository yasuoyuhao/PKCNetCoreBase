using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services
{
    static public class GeneratingResponseResultTemp<T>
    {
        public static readonly string isExisting = "isExisting";

        static public ResponseResult<T> ValidationFailure(T data, string message)
        {
            return new ResponseResult<T>(ResponseCode.connectSccessButDataProcessingIsWrong, $"Data Validation Failure { message }", data);
        }

        static public ResponseResult<T> FailureError(T data, string message = "")
        {
            return new ResponseResult<T>(ResponseCode.connectSccessButDataProcessingIsWrong, $"Unknown Error Failure { message }", data);
        }

        static public ResponseResult<T> AuthorizationFailure(T data, string message = "")
        {
            return new ResponseResult<T>(ResponseCode.connectSccessButAuthorizationFailure, $"Failure AuthorizationFailure { message }", data);
        }
    }

    static public class ResponseResultString
    {
        static public readonly string isExisting = "is existing";
        static public readonly string isNotExist = "target is not exist";
        static public readonly string systemNotAllowed = "system is no operation allowed";
    }
}
