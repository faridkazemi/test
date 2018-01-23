using BanjoTwitterExercise.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public class HttpClientHelper<T>
    {
       public IHttpApiRequest<T> Request { get; set; }
        public HttpClientHelper(IHttpApiRequest<T> request)
        {
            Request = request;
        }
        public async Task<T> PostAsync<T>()
        {
            var client = new HttpClient();
            
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Request.GetBaseAddress()}{Request.GetApiName()}{Request.GetParametersAsQueryString()}");
            requestMessage.Headers.Add(Request.Header.HeaderName, Request.Header.HeaderValue);
            
            //Due to lack of tile the SOLID doesn't follow at the bellow line 
            try
            {
                requestMessage.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<T> GettAsync<T>()
        {
            try
            {
                var client = new HttpClient();

            var parameteres = Request.GetParametersAsQueryString();
                
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Request.GetBaseAddress()}{Request.GetApiName()}?{parameteres}");
            requestMessage.Headers.Add(Request.Header.HeaderName, Request.Header.HeaderValue);
                var response = new HttpResponseMessage();
                //HttpResponseMessage response =
                await HandleExpectedExceptions(async () => response = await client.SendAsync(requestMessage));
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(json);
                else
                    throw new HttpRequestException();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task<HttpResponseMessage> HandleExpectedExceptions(Func<Task<HttpResponseMessage>> func)
        {
            var MaxRetryCount = 3;
            for (int i = 1; i <= MaxRetryCount; i++)
            {
                try
                {
                    return await func();
                }
                catch (HttpRequestException ex)
                {
                    var innerException = ex.InnerException as WebException;
                    if (innerException != null && innerException.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        if (i < MaxRetryCount)
                            Thread.Sleep(5000);         // Sleep for 5 seconds
                        else
                            throw new ApplicationException($"{MaxRetryCount} Retries failed, with exception {ex}");
                    }
                    else
                        throw ex;
                }
            }
            return null;
        }
    }
}