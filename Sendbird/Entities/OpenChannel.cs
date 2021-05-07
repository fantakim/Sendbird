using Newtonsoft.Json;

namespace Sendbird.Entities
{
    public class OpenChannel : ChannelBase
    {
        [JsonProperty("participant_count")]
        public int ParticipantCount { get; set; }
    }
}
