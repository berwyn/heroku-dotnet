using System;
using System.Threading;
using System.Threading.Tasks;

namespace Heroku.NET.Connections
{
    /// <summary>
    /// A connectiont to the API.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Get a singular resource from the API.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        Task<T> Get<T>(string fragment);

        /// <summary>
        /// Get a singular resource from the API.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        /// <param name="token">The token used to cancel this request.</param>
        Task<T> Get<T>(string fragment, CancellationToken token);

        /// <summary>
        /// Creates a new resource.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        /// <param name="payload">The object to create.</param>
        Task Post<T>(string fragment, T payload);

        /// <summary>
        /// Creates a new resource.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        /// <param name="payload">The object to create.</param>
        /// <param name="token">The token used to cancel this request.</param>
        Task Post<T>(string fragment, T payload, CancellationToken token);

        /// <summary>
        /// Creates a new resource.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        /// <param name="payload">The object to create.</param>
        Task<R> Post<R, T>(string fragment, T payload);

        /// <summary>
        /// Creates a new resource.
        /// </summary>
        /// <param name="fragment">The Uri fragment for the resource.</param>
        /// <param name="payload">The object to create.</param>
        /// <param name="token">The token used to cancel this request.</param>
        Task<R> Post<R, T>(string fragment, T payload, CancellationToken token);
    }
}
