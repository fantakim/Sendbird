using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;
using Sendbird.Infrastructure;
using System;

namespace Sendbird.Services.Messages
{
    public class MessageListOptions : ListOptions
    {
        [JsonProperty("message_ts")]
        [JsonConverter(typeof(DateTimeConverter), TimestampSize.Milliseconds)]
        public DateTime CreatedBefore { get; set; }

        [JsonProperty("message_id")]
        public long? MessageId { get; set; }

        [JsonProperty("prev_limit")]
        public int? PrevLimit { get; set; }

        [JsonProperty("next_limit")]
        public int? NextLimit { get; set; }

        [JsonProperty("reverse")]
        public bool Reverse { get; set; }

        [JsonProperty("sender_id")]
        public string SenderId { get; set; }

        [JsonProperty("sender_ids")]
        public string SenderIds { get; set; }

        [JsonProperty("message_type")]
        public MessageType? MessageType { get; set; }

        [JsonProperty("including_removed")]
        public bool IncludingRemoved { get; set; }

        [JsonProperty("include_reactions")]
        public bool IncludeReactions { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
