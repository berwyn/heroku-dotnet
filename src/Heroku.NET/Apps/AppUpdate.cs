using Newtonsoft.Json;

namespace Heroku.NET.Apps
{
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
