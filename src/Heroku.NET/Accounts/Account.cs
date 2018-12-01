using System;
using Heroku.NET.Common;
using Heroku.NET.Identity;
using Heroku.NET.Organizations;
using Newtonsoft.Json;

namespace Heroku.NET.Accounts
{
    /// <summary>
    /// An account represents an individual signed up to use the Heroku platform.
    /// </summary>
    public class Account : NamedEntity
    {
        /// <summary>
        /// Whether to allow third party web activity tracking.
        /// </summary>
        [JsonProperty("allow_tracking")]
        public bool AllowTracking { get; set; }

        /// <summary>
        /// Whether allowed to utilize beta Heroku features.
        /// </summary>
        [JsonProperty("beta")]
        public bool AreBetaFeaturesAllowed { get; set; }

        /// <summary>
        /// The organization selected by default.
        /// </summary>
        [JsonProperty("default_organization")]
        public NestedResource<Organization> DefaultOrganization { get; set; }

        /// <summary>
        /// When account became delinquent.
        /// </summary>
        [JsonProperty("delinquent_at")]
        public DateTime? DelinquentAt { get; set; }

        /// <summary>
        /// Unique email address of account.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Whether the user is federated and belongs to an Identity Provider.
        /// </summary>
        [JsonProperty("federated")]
        public bool IsFederated { get; set; }

        /// <summary>
        /// Identity Provider details for federated users.
        /// </summary>
        [JsonProperty("identity_provider")]
        public IdentityProvider IdentityProvider { get; set; }

        /// <summary>
        /// When account last authorized with Heroku.
        /// </summary>
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// SMS number of account.
        /// </summary>
        [JsonProperty("sms_number")]
        public string SmsNumber { get; set; }

        /// <summary>
        /// When the account was suspended.
        /// </summary>
        [JsonProperty("suspended_at")]
        public DateTime? SuspendedAt { get; set; }

        /// <summary>
        /// Whether two-factor auth is enabled on the account.
        /// </summary>
        [JsonProperty("two_factor_authentication")]
        public bool HasTwoFactorAuthentication { get; set; }

        /// <summary>
        /// Whether account has been verified with billing information.
        /// </summary>
        [JsonProperty("verified")]
        public bool IsVerified { get; set; }
    }
}
