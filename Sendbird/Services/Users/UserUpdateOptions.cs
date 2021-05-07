using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Users
{
    public class UserUpdateOptions : BaseOptions
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("issue_access_token")]
        public bool IssueAccessToken { get; set; }

        [JsonProperty("issue_session_token")]
        public bool IssueSessionToken { get; set; }

        [JsonProperty("session_token_expires_at")]
        public long? SessionTokenExpiresAt { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("last_seen_at")]
        public long? LastSeenAt { get; set; }

        [JsonProperty("discovery_keys")]
        public string[] DiscoveryKeys { get; set; }

        [JsonProperty("preferred_languages")]
        public string[] PreferredLanguages { get; set; }
        
        [JsonProperty("leave_all_when_deactivated")]
        public bool LeaveAllWhenDeactivated { get; set; }
    }
}
