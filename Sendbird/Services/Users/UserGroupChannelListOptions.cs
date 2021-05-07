using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;
using Sendbird.Infrastructure;
using System;

namespace Sendbird.Services.Users
{
    public class UserGroupChannelListOptions : ListOptions
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; } = 10;

        [JsonProperty("distinct_mode")]
        public DistinctMode? DistinctMode { get; set; }

        [JsonProperty("public_mode")]
        public PublicMode? PublicMode { get; set; }

        [JsonProperty("super_mode")]
        public SuperMode? SuperMode { get; set; }

        [JsonProperty("hidden_mode")]
        public HiddenMode? HiddenMode { get; set; }

        [JsonProperty("member_state_filter")]
        public MemberStateFilter? MemberStateFilter { get; set; }

        [JsonProperty("unread_filter")]
        public UnreadFilter? UnreadFilter { get; set; }

        [JsonProperty("created_after")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAfter { get; set; }

        [JsonProperty("created_before")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedBefore { get; set; }

        [JsonProperty("show_empty")]
        public bool ShowEmpty { get; set; }

        [JsonProperty("show_frozen")]
        public bool ShowFrozen { get; set; }

        [JsonProperty("show_member")]
        public bool ShowMember { get; set; }

        [JsonProperty("show_delivery_receipt")]
        public bool ShowDeliveryReceipt { get; set; }

        [JsonProperty("show_read_receipt")]
        public bool ShowReadReceipt { get; set; }

        [JsonProperty("order")]
        public OrderMode? Order { get; set; }

        [JsonProperty("metadata_order_key")]
        public string MetadataOrderKey { get; set; }

        [JsonProperty("custom_types")]
        public string CustomTypes { get; set; }

        [JsonProperty("custom_type_startswith")]
        public string CustomTypeStartswith { get; set; }

        [JsonProperty("channel_urls")]
        public string ChannelUrls { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_contains")]
        public string NameContains { get; set; }

        [JsonProperty("name_startswith")]
        public string NameStartswith { get; set; }

        [JsonProperty("members_exactly_in")]
        public string MembersExactlyIn { get; set; }

        [JsonProperty("members_include_in")]
        public string MembersIncludeIn { get; set; }

        [JsonProperty("query_type")]
        public string QueryType { get; set; }

        [JsonProperty("members_nickname")]
        public string MembersNickname { get; set; }

        [JsonProperty("members_nickname_contains")]
        public string MembersNicknameContains { get; set; }

        [JsonProperty("search_query")]
        public string SearchQuery { get; set; }

        [JsonProperty("search_fields")]
        public string SearchFields { get; set; }

        [JsonProperty("metadata_key")]
        public string MetadataKey { get; set; }

        [JsonProperty("metadata_values")]
        public string MetadataValues { get; set; }

        [JsonProperty("metadata_value_startswith")]
        public string MetadataValueStartswith { get; set; }

        [JsonProperty("metacounter_key")]
        public string MetacounterKey { get; set; }

        [JsonProperty("metacounter_values")]
        public string MetacounterValues { get; set; }

        [JsonProperty("metacounter_value_gt")]
        public string MetacounterValueGt { get; set; }

        [JsonProperty("metacounter_value_gte")]
        public string MetacounterValueGte { get; set; }

        [JsonProperty("metacounter_value_lt")]
        public string MetacounterValueLt { get; set; }

        [JsonProperty("metacounter_value_lte")]
        public string MetacounterValueLte { get; set; }
    }
}
