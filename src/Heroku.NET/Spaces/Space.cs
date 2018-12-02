using Heroku.NET.Common;
using Heroku.NET.Organizations;
using Heroku.NET.Regions;
using Heroku.NET.Teams;
using Newtonsoft.Json;

namespace Heroku.NET.Spaces
{
    /// <summary>
    /// A space is an isolated, highly available, secure app execution environments, running in the modern VPC substrate.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Space : NamedEntity
    {
        /// <summary>
        /// The RFC-1918 CIDR the Private Space will use.
        /// It must be a /16 in 10.0.0.0/8, 172.16.0.0/12 or 192.168.0.0/16.
        /// </summary>
        [JsonProperty("cidr")]
        public string Cidr { get; set; }

        /// <summary>
        /// The RFC-1918 CIDR that the Private Space will use for the
        /// Heroku-managed peering connection that’s automatically created
        /// when using Heroku Data add-ons. It must be between a /16 and a /20.
        /// </summary>
        [JsonProperty("data_cidr")]
        public string DataCidr { get; set; }

        /// <summary>
        /// The organization associated with this space.
        /// </summary>
        [JsonProperty("organization")]
        public NestedResource<Organization> Organization { get; set; }

        /// <summary>
        /// The region this space is hosted in.
        /// </summary>
        [JsonProperty("region")]
        public NestedResource<Region> Region { get; set; }

        /// <summary>
        /// Whether the space has shield enabled.
        /// </summary>
        [JsonProperty("shield")]
        public bool IsShieldEnabled { get; set; }

        /// <summary>
        /// The availability of the space.
        /// Valid values are allocating, allocated, and deleting.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// The team this space is associated with.
        /// </summary>
        [JsonProperty("team")]
        public NestedResource<Team> Team;
    }
}
