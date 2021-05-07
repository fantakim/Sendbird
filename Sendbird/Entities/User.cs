using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Infrastructure;
using System;
using System.Collections.Generic;

namespace Sendbird.Entities
{
    public class User : SendbirdEntity<User>
    {
        [JsonProperty("user_id")]
        public string Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("session_tokens")]
        public SessionToken[] SessionTokens { get; set; }

        [JsonProperty("has_ever_logged_in")]
        public long HasEverLoggedIn { get; set; }

        [JsonProperty("is_active")]
        public long IsActive { get; set; }

        [JsonProperty("is_online")]
        public long IsOnline { get; set; }

        [JsonProperty("discovery_keys")]
        public string[] DiscoveryKeys { get; set; }

        [JsonProperty("preferred_languages")]
        public string[] PreferredLanguages { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("last_seen_at")]
        [JsonConverter(typeof(DateTimeConverter), TimestampSize.Milliseconds)]
        public DateTime? LastSeenAt { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
