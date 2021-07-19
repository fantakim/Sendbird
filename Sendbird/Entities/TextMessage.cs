using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sendbird.Entities
{
    public class TextMessage : MessageBase
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("translations")]
        public Dictionary<string, string> Translations { get; set; }

        [JsonProperty("file")]
        public File File { get; set; }

        [JsonProperty("require_auth")] 
        public bool RequireAuth { get; set; }
    }
}
