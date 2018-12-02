using System;
using Heroku.NET.Common;
using Heroku.NET.Organizations;
using Newtonsoft.Json;

namespace Heroku.NET.Identity
{
    /// <summary>
    /// Identity Providers represent the SAML configuration of an Organization.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class IdentityProvider : Entity
    {
        /// <summary>
        /// Raw contents of the public certificate (eg: .crt or .pem file)
        /// </summary>
        [JsonProperty("certificate")]
        public string Certificate { get; set; }

        /// <summary>
        /// URL identifier provided by the identity provider.
        /// </summary>
        [JsonProperty("entity_id")]
        public string EntityId { get; set; }

        /// <summary>
        /// The organization associated with this identity provider.
        /// </summary>
        [JsonProperty("organization")]
        public NestedResource<Organization> Organization { get; set; }

        /// <summary>
        /// Owner of tihs provider.
        /// </summary>
        [JsonProperty("owner")]
        public NestedOwner Owner { get; set; }

        /// <summary>
        /// Single log out URL for this identity provider.
        /// </summary>
        [JsonProperty("slo_target_url")]
        public string SingleLogoutUrl { get; set; }

        /// <summary>
        /// Single sign on URL for this identity provider.
        /// </summary>
        [JsonProperty("sso_target_url")]
        public string SingleSignonUrl { get; set; }

        /// <summary>
        /// The nested properties of the owner are slightly different from other
        /// nested resources, so we have a nested class.
        /// </summary>
        public class NestedOwner
        {
            /// <summary>
            /// The ID of the owner.
            /// </summary>
            [JsonProperty("id")]
            public Guid Id { get; set; }

            /// <summary>
            /// The name of the owner.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// The type of the owner.
            /// Valid values are team and enterprise-account.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
        }
    }
}
