using System;
using Heroku.NET.Common;
using Newtonsoft.Json;

namespace Heroku.NET.Stacks
{
    /// <summary>
    /// Stacks are the different application execution environments available in the Heroku platform.
    /// </summary>
    public class Stack : NamedEntity
    {
        /// <summary>
        /// Availability of this stack. Valid values are beta, deprecated, and public
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
