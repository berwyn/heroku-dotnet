using System;
using Newtonsoft.Json;

namespace Heroku.NET.Common
{
    /// <summary>
    /// A basic representation of common identifiable objects from the API.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// A unique identifier for this resource.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The date this resource was created at.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date this resource was last updated at.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// An <cref See="Entity" /> which also has a name
    /// </summary>
    public abstract class NamedEntity : Entity
    {
        /// <summary>
        /// The name for this resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
