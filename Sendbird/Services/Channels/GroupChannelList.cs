using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using System.Collections.Generic;

namespace Sendbird.Services.Channels
{
    public class GroupChannelList : SendbirdList<GroupChannel>
    {
        [JsonProperty("channels")]
        public List<GroupChannel> Channels { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
