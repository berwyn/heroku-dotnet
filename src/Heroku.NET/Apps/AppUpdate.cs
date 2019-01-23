using Newtonsoft.Json;

namespace Heroku.NET.Apps
{
    /// <summary>
    /// An abstraction for allowed updates to an <see cref="App" />.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class AppUpdate
    {
        /// <summary>
        /// Unique name or identifier of stack.
        /// </summary>
        [JsonProperty("build_stack")]
        public string BuildStackName { get; set; }

        /// <summary>
        /// Maintenance status of app.
        /// </summary>
        [JsonProperty("maintenance")]
        public bool IsInMaintenanceMode { get; set; }

        /// <summary>
        /// Name of app.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
