using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Channels
{
    public class GroupChannelUpdateOptions : BaseOptions
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

        [JsonProperty("is_distinct")]
        public bool IsDistinct { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        [JsonProperty("operator_ids")]
        public string[] OperatorIds { get; set; }
    }
}
