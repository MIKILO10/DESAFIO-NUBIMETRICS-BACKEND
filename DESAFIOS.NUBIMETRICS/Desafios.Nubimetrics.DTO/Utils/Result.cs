using System;
using System.Collections.Generic;

namespace Desafios.Nubimetrics.DTO.Utils
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string ErrorMessage { get; }
        public int? StatusCode { get; }

        private Result(bool isSuccess, T data, string errorMessage, int? statusCode)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public static Result<T> Failure(string errorMessage, int? statusCode = null)
        {
            return new Result<T>(false, default(T), errorMessage, statusCode);
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null, 200);
        }

     
        public static Result<List<T>> Success(List<T> dataList)
        {
            return new Result<List<T>>(true, dataList, null, 200);
        }
    }
}
