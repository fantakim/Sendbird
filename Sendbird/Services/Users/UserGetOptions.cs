using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;

namespace Sendbird.Services.Users
{
    public class UserGetOptions : BaseOptions
    {
        [JsonProperty("include_unread_count")]
        public bool IncludeUnreadCount { get; set; } = false;

        [JsonProperty("custom_types")]
        public string CustomTypes { get; set; }

        [JsonProperty("super_mode")]
        public SuperMode? SuperMode { get; set; }
    }
}
