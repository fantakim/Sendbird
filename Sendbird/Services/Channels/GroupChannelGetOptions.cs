using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Enums;

namespace Sendbird.Services.Channels
{
    public class GroupChannelGetOptions : BaseOptions
    {
        [JsonProperty("show_delivery_receipt")]
        public bool ShowDeliveryReceipt { get; set; }

        [JsonProperty("show_read_receipt")]
        public bool ShowReadReceipt { get; set; }

        [JsonProperty("order")]
        public OrderMode? Order { get; set; }

        [JsonProperty("show_member")]
        public bool ShowMember { get; set; }
    }
}
