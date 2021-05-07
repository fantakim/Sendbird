using Newtonsoft.Json;
using Sendbird.Core;
using System.Collections.Generic;

namespace Sendbird.Services.Channels
{
    public class GroupChannelCreateOptions : BaseOptions
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

        [JsonProperty("is_distinct")]
        public bool IsDistinct { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("is_super")]
        public bool IsSuper { get; set; }

        [JsonProperty("is_ephemeral")]
        public bool IsEphemeral { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        [JsonProperty("inviter_id")]
        public string InviterId { get; set; }

        [JsonProperty("user_ids")]
        public string[] UserIds { get; set; }

        [JsonProperty("strict")]
        public bool Strict { get; set; }

        [JsonProperty("invitation_status")]
        public Dictionary<string, long> InvitationStatus { get; set; }

        [JsonProperty("hidden_status")]
        public Dictionary<string, long> HiddenStatus { get; set; }

        [JsonProperty("operator_ids")]
        public string[] OperatorIds { get; set; }

        [JsonProperty("block_sdk_user_channel_join")]
        public bool BlockSdkUserChannelJoin { get; set; }
    }
}
