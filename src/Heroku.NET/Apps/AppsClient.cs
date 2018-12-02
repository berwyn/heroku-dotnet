using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Heroku.NET.Common;
using Heroku.NET.Connections;

namespace Heroku.NET.Apps
{
    /// <inheritdoc />
    public class AppsClient : IAppsClient
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Constructs an <see cref="AppsClient" />.
        /// </summary>
        public AppsClient(IConnection connection)
        {
            this._connection = connection;
        }

        /// <inheritdoc />
        public Task<ReadOnlyCollection<App>> GetAll()
        {
            return this._connection.Get<ReadOnlyCollection<App>>("/apps");
        }

        /// <inheritdoc />
        public Task<App> Get(Guid id)
        {
            return this._connection.Get<App>($"/apps/{id}");
        }

        /// <inheritdoc />
        public Task<App> Get(string name)
        {
            return this._connection.Get<App>($"/apps/{name}");
        }
    }
}
