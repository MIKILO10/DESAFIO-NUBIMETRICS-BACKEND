﻿using Azure;
using Desafios.Nubimetrics.DTO.Utils;

namespace Desafios.Nubimetrics.Application.Utils.Interfaces
{
    public interface IGenericCommunication
    {
        Task<Result<TResponse>> GetAll<TResponse>(string url);
        Task<Result<TResponse>> GetAllFrom<TResponse>(string url, string from);
        Task<Result<TResponse>> GetById<TResponse>(string url, string request);
        Task<Result<TResponse>> GetByTerm<TResponse>(string url, string request);
    }

}
