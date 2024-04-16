using Newtonsoft.Json;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.DTO.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;

public class HttpCommunication : IGenericCommunication
{
    private readonly HttpClient _httpClient;

    public HttpCommunication(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<Result<TResponse>> GetAll<TResponse>(string url)
    {
        HttpResponseMessage response;
        try
        {
            // Realizar la solicitud HTTP GET
            response = await _httpClient.GetAsync(url);
        }
        catch (HttpRequestException ex)
        {
            // Manejar la excepción de la solicitud HTTP y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error al realizar la solicitud HTTP: " + ex.Message, 500);
        }

        // Verificar si la respuesta indica un error HTTP
        if (!response.IsSuccessStatusCode)
        {
            // Devolver un resultado fallido con el código de estado de la respuesta
            return Result<TResponse>.Failure($"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}", (int)response.StatusCode);
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserializar el JSON en el tipo de respuesta especificado
        TResponse result;
        try
        {
            result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            return Result<TResponse>.Success(result);
        }
        catch (JsonException ex)
        {
            // Manejar la excepción de deserialización y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error de deserialización: " + ex.Message);
        }
    }

    public async Task<Result<TResponse>> GetById<TResponse>(string url, string request)
    {
        HttpResponseMessage response;
        try
        {
            // Realizar la solicitud HTTP GET
            response = await _httpClient.GetAsync($"{url}/{request}");
        }
        catch (HttpRequestException ex)
        {
            // Manejar la excepción de la solicitud HTTP y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error al realizar la solicitud HTTP: " + ex.Message, 500);
        }

        // Verificar si la respuesta indica un error HTTP
        if (!response.IsSuccessStatusCode)
        {
            // Devolver un resultado fallido con el código de estado de la respuesta
            return Result<TResponse>.Failure($"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}", (int)response.StatusCode);
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserializar el JSON en el tipo de respuesta especificado
        TResponse result;
        try
        {
            // Usar la serialización genérica
            result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            return Result<TResponse>.Success(result);
        }
        catch (JsonException ex)
        {
            // Manejar la excepción de deserialización y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error de deserialización: " + ex.Message);
        }
    }

    public async Task<Result<TResponse>> GetByTerm<TResponse>(string url, string request)
    {
       
        HttpResponseMessage response;
        try
        {
            // Realizar la solicitud HTTP GET
            response = await _httpClient.GetAsync($"{url}{request}");
        }
        catch (HttpRequestException ex)
        {
            // Manejar la excepción de la solicitud HTTP y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error al realizar la solicitud HTTP: " + ex.Message, 500);
        }

        // Verificar si la respuesta indica un error HTTP
        if (!response.IsSuccessStatusCode)
        {
            // Devolver un resultado fallido con el código de estado de la respuesta
            return Result<TResponse>.Failure($"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}", (int)response.StatusCode);
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserializar el JSON en el tipo de respuesta especificado
        TResponse result;
        try
        {
            // Usar la serialización genérica
            result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            return Result<TResponse>.Success(result);
        }
        catch (JsonException ex)
        {
            // Manejar la excepción de deserialización y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error de deserialización: " + ex.Message);
        }
    }

    public async Task<Result<TResponse>> GetAllFrom<TResponse>(string url, string from)
    {
        HttpResponseMessage response;
        try
        {
            var urlQuery = $"{url}{from}&to=USD";

            // Realizar la solicitud HTTP GET
            response = await _httpClient.GetAsync(urlQuery);
        }
        catch (HttpRequestException ex)
        {
            // Manejar la excepción de la solicitud HTTP y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error al realizar la solicitud HTTP: " + ex.Message, 500);
        }

        // Verificar si la respuesta indica un error HTTP
        if (!response.IsSuccessStatusCode)
        {
            // Devolver un resultado fallido con el código de estado de la respuesta
            return Result<TResponse>.Failure($"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}", (int)response.StatusCode);
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserializar el JSON en el tipo de respuesta especificado
        TResponse result;
        try
        {
            // Usar la serialización genérica
            result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            return Result<TResponse>.Success(result);
        }
        catch (JsonException ex)
        {
            // Manejar la excepción de deserialización y devolver un resultado con el mensaje de error
            return Result<TResponse>.Failure("Error de deserialización: " + ex.Message);
        }

    }
}
