using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using Sendbird.Enums;

namespace Sendbird.Services.Messages
{
    public class AdminMessageOptions : BaseOptions
    {
        public AdminMessageOptions()
        {
            MessageType = MessageType.AdminMessage;
        }

        [JsonProperty("message_type")]
        protected MessageType MessageType { get; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("custom_type")]
        public string CustomType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("send_push")]
        public bool? SendPush { get; set; }

        [JsonProperty("mention_type")]
        public MentionType? MentionType { get; set; }

        [JsonProperty("mentioned_users")]
        public User[] MentionedUsers { get; set; }

        [JsonProperty("is_silent")]
        public bool? IsSilent { get; set; }

        [JsonProperty("created_at")]
        public long? CreatedAt { get; set; }

        [JsonProperty("dedup_id")]
        public string DedupId { get; set; }
    }
}
