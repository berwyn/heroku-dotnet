using System;
using Heroku.NET.Common;
using Newtonsoft.Json;

namespace Heroku.NET.Organizations
{
    /// <summary>
    /// Deprecated: Organizations allow you to manage access to a shared group of applications across your development team.
    /// </summary>
    [Obsolete]
    public class Organization : NamedEntity
    {
        /// <summary>
        /// whether charges incurred by the org are paid by credit card.
        /// </summary>
        [JsonProperty("credit_card_collections")]
        public bool UsesCreditCardCollections { get; set; }

        /// <summary>
        /// whether to use this organization when none is specified.
        /// </summary>
        [JsonProperty("default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// The upper limit of members allowed in an organization.
        /// </summary>
        [JsonProperty("membership_limit")]
        public int? MembershipLimit { get; set; }

        /// <summary>
        /// Whether the org is provisioned licenses by salesforce.
        /// </summary>
        [JsonProperty("provisioned_licenses")]
        public bool HasProvisionedLicenses { get; set; }

        /// <summary>
        /// Role in the organization
        /// Valid values are admin, collaborator, member, owner, or null.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }


        /// <summary>
        /// Type of organization..
        /// Valid values are enterprise and team.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
