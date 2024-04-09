using IPE.SmsIrClient.Exceptions;
using IPE.SmsIrClient.Models.Results;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace IPE.SmsIrClient.Extensions
{
    internal static class HttpRequestExtensions
    {
        internal static async Task<SmsIrResult<TResult>> GetRequestAsync<TResult>(this HttpClient httpClient, string requestUri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
                await HandleUnsuccessfulResponse(response);

            return await response.Content.ReadFromJsonAsync<SmsIrResult<TResult>>();
        }

        internal static async Task<SmsIrResult<TResult>> PostRequestAsync<TResult>(this HttpClient httpClient, string requestUri, object data)
        {
            string payload = JsonSerializer.Serialize(data);

            StringContent httpContent = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(requestUri, httpContent);

            if (!response.IsSuccessStatusCode)
                await HandleUnsuccessfulResponse(response);

            return await response.Content.ReadFromJsonAsync<SmsIrResult<TResult>>();
        }

        internal static async Task<SmsIrResult<TResult>> DeleteRequestAsync<TResult>(this HttpClient httpClient, string requestUri)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
                await HandleUnsuccessfulResponse(response);

            return await response.Content.ReadFromJsonAsync<SmsIrResult<TResult>>();
        }

        private static async Task HandleUnsuccessfulResponse(HttpResponseMessage response)
        {
            SmsIrResult baseResponse = await response.Content.ReadFromJsonAsync<SmsIrResult>();
            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 401:
                    throw new UnauthorizedException(baseResponse.Status, baseResponse.Message);
                case 403:
                    throw new AccessDeniedException(baseResponse.Status, baseResponse.Message);
                case 400:
                    throw new LogicalException(baseResponse.Status, baseResponse.Message);
                case 429:
                    throw new TooManyRequestException(baseResponse.Status, baseResponse.Message);
                case 500:
                    throw new UnexpectedException(baseResponse.Status, baseResponse.Message);
                default:
                    throw new InvalidOperationException($"something went wrong, httpStatus code: {response.StatusCode}, message: {response.RequestMessage}, please contact support team.");
            }
        }
    }
}