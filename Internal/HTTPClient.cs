using System.Web;
using System.Net;

namespace LoadShedding.NET.Internal
{
    public abstract class HTTPClient
    {
        private HttpClient _client;
        private string _url;

        public string Url
        {
            get { return _url; }
        }

        public HTTPClient(string url)
        {
            _client = new HttpClient();
            _url = url;
        }

        public async Task<HttpResponseMessage> Get(string path)
        {
            string uri = _url + path;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _client.GetAsync(uri);
            }
            catch (HttpRequestException hre)
            {
                //Log message somewhere
                HttpStatusCode code = HttpStatusCode.GatewayTimeout;
                if (hre.StatusCode.HasValue)
                {
                    code = hre.StatusCode.Value;
                }
                response.StatusCode = code;
            }
            return response;

        }

    }
}