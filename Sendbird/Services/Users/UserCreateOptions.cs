using Newtonsoft.Json;
using Sendbird.Core;
using System.Collections.Generic;

namespace Sendbird.Services.Users
{
    public class UserCreateOptions : BaseOptions
    {
        [JsonProperty("user_id")]
        public string Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; } = string.Empty;

        [JsonProperty("issue_access_token")]
        public bool? IssueAccessToken { get; set; }

        [JsonProperty("issue_session_token")]
        public bool? IssueSessionToken { get; set; }

        [JsonProperty("session_token_expires_at")]
        public long? SessionTokenExpiresAt { get; set; }

        [JsonProperty("discovery_keys")]
        public string[] DiscoveryKeys { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
