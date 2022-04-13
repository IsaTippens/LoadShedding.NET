using System.Net.Http;

namespace LoadShedding.NET.REST
{
    public class HTTPClient
    {
        private HttpClient _client;
        private const string URL = "http://loadshedding.eskom.co.za/LoadShedding";
        public HTTPClient()
        {
            _client = new HttpClient();
        }

        public string Get(string path)
        {
            return _client.GetStringAsync(URL + path).Result;
        }
    }
}