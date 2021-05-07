using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using Sendbird.Enums;

namespace Sendbird.Services.Messages
{
    public class TextMessageOptions : BaseOptions
    {
        public TextMessageOptions()
        {
            MessageType = MessageType.Message;
        }

        [JsonProperty("message_type")]
        protected MessageType MessageType { get; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("send_push")]
        public bool SendPush { get; set; }

        [JsonProperty("mention_type")]
        public MentionType? MentionType { get; set; }

        [JsonProperty("mentioned_users")]
        public User[] MentionedUsers { get; set; }
    }
}
