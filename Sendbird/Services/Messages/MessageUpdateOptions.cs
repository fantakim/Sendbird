using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using Sendbird.Enums;

namespace Sendbird.Services.Messages
{
    public class MessageUpdateOptions : BaseOptions
    {
        [JsonProperty("message_type")]
        public MessageType MessageType { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("mention_type")]
        public MentionType? MentionType { get; set; }

        [JsonProperty("mentioned_users")]
        public User[] MentionedUsers { get; set; }

        public void SetMessageType(MessageType messageType)
        {
            MessageType = messageType;
        }
    }
}
