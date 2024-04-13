using IPE.SmsIrClient.Exceptions;
using IPE.SmsIrClient.Models.Results;
using System;
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
            HttpResponseMessage response = await SendRequestAsync(httpClient, HttpMethod.Get, requestUri);
            return await ProcessResponseAsync<TResult>(response);
        }

        internal static SmsIrResult<TResult> GetRequest<TResult>(this HttpClient httpClient, string requestUri)
        {
            HttpResponseMessage response = SendRequest(httpClient, HttpMethod.Get, requestUri);
            return ProcessResponse<TResult>(response);
        }

        internal static async Task<SmsIrResult<TResult>> PostRequestAsync<TResult>(this HttpClient httpClient, string requestUri, object data)
        {
            HttpResponseMessage response = await SendRequestAsync(httpClient, HttpMethod.Post, requestUri, data);
            return await ProcessResponseAsync<TResult>(response);
        }

        internal static SmsIrResult<TResult> PostRequest<TResult>(this HttpClient httpClient, string requestUri, object data)
        {
            HttpResponseMessage response = SendRequest(httpClient, HttpMethod.Post, requestUri, data);
            return ProcessResponse<TResult>(response);
        }

        internal static async Task<SmsIrResult<TResult>> DeleteRequestAsync<TResult>(this HttpClient httpClient, string requestUri)
        {
            HttpResponseMessage response = await SendRequestAsync(httpClient, HttpMethod.Delete, requestUri);
            return await ProcessResponseAsync<TResult>(response);
        }

        internal static SmsIrResult<TResult> DeleteRequest<TResult>(this HttpClient httpClient, string requestUri)
        {
            HttpResponseMessage response = SendRequest(httpClient, HttpMethod.Delete, requestUri);
            return ProcessResponse<TResult>(response);
        }

        private static async Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, HttpMethod method, string requestUri, object data = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri);
            if (data != null)
            {
                string payload = JsonSerializer.Serialize(data);
                request.Content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            }

            return await httpClient.SendAsync(request);
        }

        private static HttpResponseMessage SendRequest(HttpClient httpClient, HttpMethod method, string requestUri, object data = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri);
            if (data != null)
            {
                string payload = JsonSerializer.Serialize(data);
                request.Content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            }

            return httpClient.SendAsync(request).GetAwaiter().GetResult();
        }

        private static async Task<SmsIrResult<TResult>> ProcessResponseAsync<TResult>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                await ProcessUnsuccessfulResponseAsync(response);

            return await response.Content.ReadFromJsonAsync<SmsIrResult<TResult>>();
        }

        private static SmsIrResult<TResult> ProcessResponse<TResult>(HttpResponseMessage response)
        {
            return ProcessResponseAsync<TResult>(response).GetAwaiter().GetResult();
        }

        private static async Task ProcessUnsuccessfulResponseAsync(HttpResponseMessage response)
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
                    throw new InvalidOperationException($"Something went wrong, HttpStatus code: {response.StatusCode}, Message: {response.RequestMessage}, please contact support team.");
            }
        }
    }
}