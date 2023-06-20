using EleventhApplication.IServices;
using System.Net;
using System.Text.Json;

namespace EleventhApplication.Services
{
    public class MyService: IMyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public MyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

       

        public async Task<Dictionary<string, object>> Method(string symbol)
        {
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={symbol}&token={_configuration["FinnhubToken"]}"),
                    Method = HttpMethod.Get,

                };
                HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {

                    string body = await httpResponse.Content.ReadAsStringAsync();

                    Stream stream = httpResponse.Content.ReadAsStream();
                    StreamReader streamReader = new StreamReader(stream);
                    string response = streamReader.ReadToEnd();
                    Dictionary<string, object> responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response)!;
                    return responseDictionary;
                }
                else 
                { 
                    throw new Exception("Something went wrong");
                }
            }
        }
    }
}
