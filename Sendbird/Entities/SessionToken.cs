using Newtonsoft.Json;
using Sendbird.Infrastructure;
using System;

namespace Sendbird.Entities
{
    public class SessionToken
    {
        [JsonProperty("session_token")]
        public string Token { get; set; }

        [JsonProperty("expires_at")]
        [JsonConverter(typeof(DateTimeConverter), TimestampSize.Milliseconds)]
        public DateTime ExpiresAt { get; set; }
    }
}
