using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Heroku.NET.Apps
{
    /// <summary>
    /// A client to manage Heroku Apps.
    /// </summary>
    public interface IAppsClient
    {
        /// <summary>
        /// Get all apps.
        /// </summary>
        Task<ReadOnlyCollection<App>> GetAll();

        /// <summary>
        /// Get an app by its ID.
        /// </summary>
        /// <param name="id">The ID of the app</param>
        Task<App> Get(Guid id);

        /// <summary>
        /// Getan an app by its name.
        /// </summary>
        /// <param name="name">The name of the app</param>
        Task<App> Get(string name);

        /// <summary>
        /// Create a new app.
        /// </summary>
        /// <param name="newApp">The app to create.</param>
        Task<App> Create(App newApp);

        /// <summary>
        /// Updates an app.
        /// </summary>
        /// <param name="app">An <see cref="App" /> to update.</param>
        Task<App> Update(App app);

        /// <summary>
        /// Updates an app.
        /// </summary>
        /// <param name="update">The update to commit.</param>
        /// <param name="id">The id of the app to update.</param>
        Task<App> Update(AppUpdate update, Guid id);
    }
}
