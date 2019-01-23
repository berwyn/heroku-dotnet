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

#region IAppsClient Members

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

        /// <inheritdoc />
        public Task<App> Create(App newApp)
        {
            return this._connection.Post<App, App>($"/apps", newApp);
        }

        /// <inheritdoc />
        public Task<App> Update(App app)
        {
            return this.Update((AppUpdate)app, app.Id);
        }

        /// <inheritdoc />
        public Task<App> Update(AppUpdate update, Guid id)
        {
            return this._connection.Patch<App, AppUpdate>($"/apps/{id}", update);
        }

        /// <inheritdoc />
        public Task<App> EnableACM(App app)
        {
            return this._connection.Post<App, object>($"/apps/{app.Id}/acm", null);
        }

        /// <inheritdoc />
        public Task<App> DisableACM(App app)
        {
            return this._connection.Delete<App>($"/apps/{app.Id}/acm");
        }

        /// <inheritdoc />
        public Task<App> RefreshACM(App app)
        {
            return this._connection.Patch<App, object>($"/apps/{app.Id}/acm", null);
        }

#endregion
    }
}
