using System;
using System.Net.Http;

namespace DodoWare.Mvc.Test
{
    public sealed class DodoWareWeb : IDisposable
    {
        public static DodoWareWeb Singleton = new DodoWareWeb("http://192.168.0.111/DodoWareMvc/");

        public Uri BaseUri { get; }
        private readonly HttpClient _httpClient;
        
        private DodoWareWeb(string url)
        {
            BaseUri = new Uri(url);
            _httpClient = new HttpClient();
        }

        public DodoWareResult Get(String resource)
        {
            var uri = new Uri(BaseUri, resource);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return SendMessage(httpRequestMessage);
        }

        public DodoWareResult Post(String resource, DodoWareData data)
        {
            var uri = new Uri(BaseUri, resource);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            httpRequestMessage.Content = data.GetContent();
            return SendMessage(httpRequestMessage);
        }

        private DodoWareResult SendMessage(HttpRequestMessage httpRequestMessage)
        {
            var requestTask = _httpClient.SendAsync(httpRequestMessage);
            if (!requestTask.Wait(20 * 1000))
            {
                throw new Exception($"Request timeout: url={httpRequestMessage.RequestUri}");
            }
            var httpResult = requestTask.Result;
            if (httpResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"HTTP error: url={httpRequestMessage.RequestUri} status={httpResult.StatusCode}");
            }
            var contentTask = httpResult.Content.ReadAsStringAsync();
            if (!contentTask.Wait(20 * 1000))
            {
                throw new Exception($"Content timeout: url={httpRequestMessage.RequestUri}");
            }
            var contentString = contentTask.Result;
            return new DodoWareResult(contentString);
        }

        public void Dispose()
        {
            if (_httpClient != null) _httpClient.Dispose();
        }
    }
}
