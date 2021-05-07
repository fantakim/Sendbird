using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using System.Collections.Generic;

namespace Sendbird.Services.Channels
{
    public class OpenChannelList : SendbirdList<OpenChannel>
    {
        [JsonProperty("channels")]
        public List<OpenChannel> Channels { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
