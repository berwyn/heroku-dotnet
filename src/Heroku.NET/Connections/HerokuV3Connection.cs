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
    public partial class HerokuV3Connection
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

        /// <summary>
        /// Creates an HTTP GET request with the correct headers.
        /// </summary>
        /// <param name="target">The URI to request.</param>
        private HttpRequestMessage CreateGetRequest(Uri target)
        {
            return CreateRequest(target, HttpMethod.Get);
        }

        /// <summary>
        /// Creates an HTTP POST request with the correct headers.
        /// </summary>
        /// <param name="target">The URI to request.</param>
        /// <param name="payload">The object to send.</param>
        private HttpRequestMessage CreatePostRequest(Uri target, object payload)
        {
            var request = CreateRequest(target, HttpMethod.Post);
            var body = JsonConvert.SerializeObject(payload);
            request.Content = new StringContent(body);
            return request;
        }

        /// <summary>
        /// Creates an HTTP PATCH request with the correct headers.
        /// </summary>
        /// <param name="target">The URI to request.</param>
        /// <param name="payload">The object to send.</param>
        private HttpRequestMessage CreatePatchRequest(Uri target, object payload)
        {
            var request = CreateRequest(target, new HttpMethod("PATCH"));
            var body = JsonConvert.SerializeObject(payload);
            request.Content = new StringContent(body);
            return request;
        }

        private HttpRequestMessage CreateDeleteRequest(Uri target)
        {
            return CreateRequest(target, HttpMethod.Delete);
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

    public partial class HerokuV3Connection : IConnection
    {
        /// <inheritdoc />
        public Task<T> Get<T>(string fragment)
        {
            return this.Get<T>(fragment, default);
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

        /// <inheritdoc />
        public Task Post<T>(string fragment, T payload)
        {
            return this.Post<T>(fragment, payload, default);
        }

        /// <inheritdoc />
        public Task Post<T>(string fragment, T payload, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = this.CreatePostRequest(uri, payload);
            return _client.SendAsync(req, token);
        }

        /// <inheritdoc />
        public Task<R> Post<R, T>(string fragment, T payload)
        {
            return this.Post<R, T>(fragment, payload, default);
        }

        /// <inheritdoc />
        public async Task<R> Post<R, T>(string fragment, T payload, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = CreatePostRequest(uri, payload);
            var res = await _client.SendAsync(req, token);
            var body = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(body);
        }

        /// <inheritdoc />
        public Task Patch<T>(string fragment, T payload)
        {
            return this.Patch<T>(fragment, payload, default);
        }

        /// <inheritdoc />
        public async Task Patch<T>(string fragment, T payload, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = this.CreatePatchRequest(uri, payload);
            await _client.SendAsync(req, token);
        }

        /// <inheritdoc />
        public Task<R> Patch<R, T>(string fragment, T payload)
        {
            return this.Patch<R, T>(fragment, payload, default);
        }

        /// <inheritdoc />
        public async Task<R> Patch<R, T>(string fragment, T payload, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = CreatePatchRequest(uri, payload);
            var res = await this._client.SendAsync(req, token);
            var body = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(body);
        }

        /// <inheritdoc />
        public Task Delete(string fragment)
        {
            return this.Delete(fragment, default);
        }

        /// <inheritdoc />
        public async Task Delete(string fragment, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = this.CreateDeleteRequest(uri);
            await _client.SendAsync(req, token);
        }

        /// <inheritdoc />
        public Task<R> Delete<R>(string fragment)
        {
            return this.Delete<R>(fragment, default);
        }

        /// <inheritdoc />
        public async Task<R> Delete<R>(string fragment, CancellationToken token)
        {
            var uri = new Uri($"{this._host}{fragment}");
            var req = CreateDeleteRequest(uri);
            var res = await this._client.SendAsync(req, token);
            var body = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(body);
        }
    }
}
