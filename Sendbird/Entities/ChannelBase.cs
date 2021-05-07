using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Infrastructure;
using System;
using System.Collections.Generic;

namespace Sendbird.Entities
{
    public class ChannelBase : SendbirdEntity<ChannelBase>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("channel_url")]
        public string ChannelUrl { get; set; }

        [JsonProperty("cover_url")]
        public string CoverUrl { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("is_ephemeral")]
        public bool IsEphemeral { get; set; }

        [JsonProperty("max_length_message")]
        public int MaxLengthMessage { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("operators")]
        public List<User> Operators { get; set; }

        [JsonProperty("freeze")]
        public bool Freeze { get; set; }
    }
}
