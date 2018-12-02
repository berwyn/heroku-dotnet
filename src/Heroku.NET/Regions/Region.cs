using Heroku.NET.Common;
using Newtonsoft.Json;

namespace Heroku.NET.Regions
{
    /// <summary>
    /// A region represents a geographic location in which your application may run.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Region : NamedEntity
    {
        /// <summary>
        /// Country where the region exists.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Description of the region.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Area in the country where the region exists.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Whether or not the region is available for creating Private Spaces.
        /// </summary>
        [JsonProperty("private_capable")]
        public bool IsPrivateCapable { get; set; }

        /// <summary>
        /// The provider for the region.
        /// </summary>
        [JsonProperty("provider")]
        public RegionProvider Provider { get; set; }

        /// <summary>
        /// The provider for this region.
        /// </summary>
        public class RegionProvider
        {
            /// <summary>
            /// Name of the provider.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Region name used by the provider.
            /// </summary>
            [JsonProperty("region")]
            public string Region { get; set; }
        }
    }
}
