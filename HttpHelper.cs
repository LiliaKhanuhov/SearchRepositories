using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;


namespace RepositoriesManager
{
    public class HttpHelper
    {
        private readonly HttpClient _httpClient;

        public HttpHelper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Get(string url)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
                request.Headers.Add("User-Agent", "test");

                using (var cts = new CancellationTokenSource())
                {

                    HttpResponseMessage response = await _httpClient.SendAsync(request, cts.Token);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        Console.WriteLine($"GET request failed for {url}");
                        throw new Exception("GET request failed");
                    }
                }
            }
        }
    }
}
