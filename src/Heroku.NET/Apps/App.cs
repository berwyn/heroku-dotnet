using System;
using System.Runtime.Serialization;
using Heroku.NET.Accounts;
using Heroku.NET.Common;
using Heroku.NET.Organizations;
using Heroku.NET.Regions;
using Heroku.NET.Spaces;
using Heroku.NET.Stacks;
using Heroku.NET.Teams;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Heroku.NET.Apps
{
    /// <summary>
    /// An app represents the program that you would like to deploy and run on Heroku.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class App : NamedEntity
    {
        /// <summary>
        /// The ACM status of the app.
        /// </summary>
        [JsonProperty("acm")]
        public bool IsAcmEnabled { get; set; }

        /// <summary>
        /// When the app was archived.
        /// </summary>
        [JsonProperty("archived_at")]
        public DateTime? ArchivedAt { get; set; }

        /// <summary>
        /// The stack used to build the app.
        /// </summary>
        [JsonProperty("build_stack")]
        public NestedResource<Stack> BuildStack { get; set; }

        /// <summary>
        /// Description from the buildpack for the app.
        /// </summary>
        [JsonProperty("buildpack_provided_description")]
        public string BuildpackProvidedDescription { get; set; }

        /// <summary>
        /// Git repo URL of the app.
        /// </summary>
        [JsonProperty("git_url")]
        public string GitUrl { get; set; }

        /// <summary>
        /// Describes whether a Private Spaces app is externally routable or not.
        /// </summary>
        [JsonProperty("internal_routing")]
        public bool? IsInternallyRoutable { get; set; }

        /// <summary>
        /// The maintenance status of the app.
        /// </summary>
        [JsonProperty("maintenance_mode")]
        public bool IsInMaintenanceMode { get; set; }

        /// <summary>
        /// The organization the app belongs to.
        /// </summary>
        [JsonProperty("organization")]
        public NestedResource<Organization> Organization { get; set; }

        /// <summary>
        /// The app's owner.
        /// </summary>
        [JsonProperty("owner")]
        public NestedResource<Account> Owner { get; set; }

        /// <summary>
        /// The region the app is deployed in.
        /// </summary>
        [JsonProperty("region")]
        public NestedResource<Region> Region { get; set; }

        /// <summary>
        /// When the app was released.
        /// </summary>
        [JsonProperty("released_at")]
        public DateTime? ReleasedAt { get; set; }

        /// <summary>
        /// The size of the app's git repo in bytes.
        /// </summary>
        [JsonProperty("repo_size")]
        public int? RepoSize { get; set; }

        /// <summary>
        /// The size of the app's slug in bytes.
        /// </summary>
        [JsonProperty("slug_size")]
        public int? SlugSize { get; set; }

        /// <summary>
        /// The space this app is deployed in.
        /// </summary>
        [JsonProperty("space")]
        public NestedResource<Space> Space { get; set; }

        /// <summary>
        /// The stack this app is built on.
        /// </summary>
        [JsonProperty("stack")]
        public NestedResource<Stack> Stack { get; set; }

        /// <summary>
        /// Identity of the team.
        /// </summary>
        [JsonProperty("team")]
        public NestedResource<Team> Team { get; set; }

        /// <summary>
        /// Web URL of the app.
        /// </summary>
        [JsonProperty("web_url")]
        public string WebUrl { get; set; }
    }
}
