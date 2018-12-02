using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Heroku.NET.Connections
{
    /// <summary>
    /// An <see cref="IConnection" /> for Heroku's API V3.
    /// </summary>
    public class HerokuV3Connection : IConnection
    {
        private readonly HttpClient _client;
        private readonly Assembly _assembly;
        private readonly string _host;

        /// <summary>
        /// Constructs a <see cref="HerokuV3Connection" />.
        /// </summary>
        public HerokuV3Connection(HttpClient client, string host)
        {
            this._client = client;
            this._assembly = Assembly.GetAssembly(typeof(HerokuV3Connection));
            this._host = host;
        }

        /// <inheritdoc />
        public Task<T> Get<T>(string fragment)
        {
            return this.Get<T>(fragment, default(CancellationToken));
        }

        /// <inheritdoc />
        public async Task<T> Get<T>(string fragment, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = this.CreateGetRequest(uri);
            var res = await _client.SendAsync(req, token);
            var body = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);
        }

        /// <summary>
        /// Creates an HTTP GET request with the correct headers.
        /// </summary>
        /// <param name="target">The URI to request.</param>
        private HttpRequestMessage CreateGetRequest(Uri target)
        {
            return CreateRequest(target, HttpMethod.Get);
        }

        /// <summary>
        /// Creates an HTTP request with the correct headers.
        /// </summary>
        /// <param name="target">The URI to request.</param>
        /// <param name="method">The request method to use.</param>
        private HttpRequestMessage CreateRequest(Uri target, HttpMethod method)
        {
            var message = new HttpRequestMessage
            {
                RequestUri = target,
                Method = method,
            };

            message.Headers.Add("Accept", "application/vnd.heroku+json; version=3");
            message.Headers.Add("User-Agent", $"Heroku.NET/{this._assembly.GetName().Version}");

            return message;
        }
    }
}
