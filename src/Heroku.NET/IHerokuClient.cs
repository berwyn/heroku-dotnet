using System;
using Heroku.NET.Apps;

namespace Heroku.NET
{
    /// <summary>
    /// An abstraction over Heroku's API.
    /// </summary>
    public interface IHerokuClient
    {
        /// <summary>
        /// A client to interact with Heroku apps.
        /// </summary>
        IAppsClient Apps { get; }
    }
}
