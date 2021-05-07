using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Channels
{
    public class OpenChannelCreateOptions : BaseOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("channel_url")]
        public string ChannelUrl { get; set; }

        [JsonProperty("cover_url")]
        public string CoverUrl { get; set; }

        [JsonProperty("cover_file")]
        public string CoverFile { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("is_ephemeral")]
        public bool IsEphemeral { get; set; }

        [JsonProperty("operator_ids")]
        public string[] OperatorIds { get; set; }
    }
}
