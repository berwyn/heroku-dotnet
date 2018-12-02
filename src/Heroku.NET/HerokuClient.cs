using System.Net.Http;
using Heroku.NET.Apps;
using Heroku.NET.Connections;

namespace Heroku.NET
{
    /// <summary>
    /// An implementation of the Heroku API Client.
    /// </summary>
    public class HerokuClient : IHerokuClient
    {
        private string _apiKey;
        private HttpClient _http;

        /// <inheridoc />
        public IAppsClient Apps { get; }

        /// <summary>
        /// Constructs a <see cref="HerokuClient" />.
        /// </summary>
        /// <param Name="apiKey">The API key to authenticate to the API with.</param>
        public HerokuClient(string apiKey) : this(apiKey, new HttpClient())
        {
        }

        /// <summary>
        /// Constructs a <see cref="HerokuClient" /> with an API key and a known <see cref="HttpClient" />.
        /// </summary>
        /// <param Name="apiKey">The API key to authenticate to the API with.</param>
        /// <param Name="http">The <cref See="HttpClient" /> to make requests with.</param>
        public HerokuClient(string apiKey, HttpClient http)
        {
            this._apiKey = apiKey;
            this._http = http;

            var connection = new HerokuV3Connection(http);
            this.Apps = new AppsClient(connection);
        }
    }
}
