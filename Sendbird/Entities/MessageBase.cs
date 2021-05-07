using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;
using Sendbird.Infrastructure;
using System;

namespace Sendbird.Entities
{
    public class MessageBase : SendbirdEntity<MessageBase>
    {
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("type")]
        public MessageType Type { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("channel_url")]
        public string ChannelUrl { get; set; }

        [JsonProperty("mention_type")]
        public MentionType? MentionType { get; set; }

        [JsonProperty("mentioned_users")]
        public User[] MentionedUsers { get; set; }

        [JsonProperty("is_removed")]
        public bool IsRemoved { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverter), TimestampSize.Milliseconds)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(DateTimeConverter), TimestampSize.Milliseconds)]
        public DateTime? UpdatedAt { get; set; }
    }
}
