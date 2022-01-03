using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Services.Channels
{
    public class GroupChannelLeaveOptions : BaseOptions
    {
        [JsonProperty("user_ids")]
        public string[] UserIds { get; set; }

        [JsonProperty("should_leave_all")]
        public bool ShouldLeaveAll { get; set; }
    }
}
