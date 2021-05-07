using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sendbird.Entities
{
    public class GroupChannel : ChannelBase
    {
        [JsonProperty("is_distinct")]
        public bool IsDistinct { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("is_super")]
        public bool IsSuper { get; set; }

        [JsonProperty("is_access_code_required")]
        public bool IsAccessCodeRequired { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("joined_member_count")]
        public int JoinedMemberCount { get; set; }

        [JsonProperty("members")]
        public List<User> Members { get; set; }

        [JsonProperty("read_receipt")]
        public Dictionary<string, long> ReadReceipt { get; set; }

        [JsonProperty("unread_message_count")]
        public int UnreadMessageCount { get; set; }

        [JsonProperty("unread_mention_count")]
        public int UnreadMentionCount { get; set; }

        [JsonProperty("last_message")]
        public TextMessage LastMessage { get; set; }
    }
}
