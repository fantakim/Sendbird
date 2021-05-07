using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;

namespace Sendbird.Services.Users
{
    public class UserListOptions : ListOptions
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; } = 10;

        [JsonProperty("active_mode")]
        public ActiveMode? ActiveMode { get; set; }

        [JsonProperty("show_bot")]
        public bool ShowBot { get; set; }

        [JsonProperty("user_ids")]
        public string UserIds { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("nickname_startswith")]
        public string NicknameStartswith { get; set; }

        [JsonProperty("metadatakey")]
        public string Metadatakey { get; set; }

        [JsonProperty("metadatavalues_in")]
        public string MetadatavaluesIn { get; set; }
    }
}
