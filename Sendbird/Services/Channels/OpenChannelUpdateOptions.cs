using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Channels
{
    public class OpenChannelUpdateOptions : BaseOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cover_url")]
        public string CoverUrl { get; set; }

        [JsonProperty("cover_file")]
        public string CoverFile { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("operator_ids")]
        public string[] OperatorIds { get; set; }
    }
}
