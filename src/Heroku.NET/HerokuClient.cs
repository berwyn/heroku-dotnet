using System.Net.Http;

namespace Heroku.NET
{
    /// <summary>
    /// An implementation of the Heroku API Client
    /// </summary>
    public class HerokuClient : IHerokuClient
    {
        private string _apiKey;
        private HttpClient _http;

        /// <summary>
        /// Constructs a <cref see="HerokuClient" />.
        /// </summary>
        /// <param Name="apiKey">The API key to authenticate to the API with.</param>
        public HerokuClient(string apiKey) : this(apiKey, new HttpClient())
        {
        }

        /// <summary>
        /// Constructs a <cref See="HerokuClient" /> with an API key and a known <cref See="HttpClient" />.
        /// </summary>
        /// <param Name="apiKey">The API key to authenticate to the API with.</param>
        /// <param Name="http">The <cref See="HttpClient" /> to make requests with.</param>
        public HerokuClient(string apiKey, HttpClient http)
        {
            this._apiKey = apiKey;
            this._http = http;
        }
    }
}
