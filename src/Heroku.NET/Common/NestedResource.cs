using System;
using Newtonsoft.Json;

namespace Heroku.NET.Common
{
    /// <summary>
    /// A shallow reference to another entity.
    /// </summary>
    public class NestedResource<T>
        where T : NamedEntity
    {
        /// <summary>
        /// The ID of the referenced entity.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the referenced entity.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
