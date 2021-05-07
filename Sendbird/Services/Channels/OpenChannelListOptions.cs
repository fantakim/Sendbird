using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Channels
{
    public class OpenChannelListOptions : ListOptions
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; } = 10;

        [JsonProperty("custom_types")]
        public string CustomTypes { get; set; }

        [JsonProperty("name_contains")]
        public string NameContains { get; set; }

        [JsonProperty("url_contains")]
        public string UrlContains { get; set; }

        [JsonProperty("show_frozen")]
        public bool ShowFrozen { get; set; }
    }
}
