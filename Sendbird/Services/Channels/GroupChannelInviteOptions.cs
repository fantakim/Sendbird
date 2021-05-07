using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;

namespace Sendbird.Services.Channels
{
    public class GroupChannelInviteOptions : BaseOptions
    {
        [JsonProperty("user_ids")]
        public string[] UserIds { get; set; }

        public User[] Users { get; set; }
    }
}
