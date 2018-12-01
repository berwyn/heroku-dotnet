using Heroku.NET.Common;
using Newtonsoft.Json;

namespace Heroku.NET.Teams
{
    /// <summary>
    /// Teams allow you to manage access to a shared group of applications and other resources.
    /// </summary>
    public class Team : NamedEntity
    {
        /// <summary>
        /// Whether charges incurred by this team are paid by credit card.
        /// </summary>
        [JsonProperty("credit_card_collections")]
        public bool UsesCreditCardCollections { get; set; }

        /// <summary>
        /// Whether to use this team when none is specified.
        /// </summary>
        [JsonProperty("default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Upper limit of members allowed on the team.
        /// </summary>
        [JsonProperty("membership_limit")]
        public int? MembershipLimit { get; set; }

        /// <summary>
        /// Whether this team is provisioned licenses by SalesForce.
        /// </summary>
        [JsonProperty("provisioned_licenses")]
        public bool HasProvisionedLicenses { get; set; }

        /// <summary>
        /// Role in the team.
        /// Valid values are admin, collaborator, member, owner, or null.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// The type of team.
        /// VAlid values are enterprise or team.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
