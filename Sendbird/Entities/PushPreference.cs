using Newtonsoft.Json;
using Sendbird.Core;

namespace Sendbird.Entities
{
    public class PushPreference : SendbirdEntity<PushPreference>
    {
        [JsonProperty("push_trigger_option")]
        public string PushTriggerOption { get; set; }

        [JsonProperty("do_not_disturb")]
        public bool DoNotDisturb { get; set; }

        [JsonProperty("start_hour")]
        public int StartHour { get; set; }

        [JsonProperty("start_min")]
        public int StartMin { get; set; }

        [JsonProperty("end_hour")]
        public int EndHour { get; set; }

        [JsonProperty("end_min")]
        public int EndMin { get; set; }

        [JsonProperty("snooze_enabled")]
        public bool SnoozeEnabled { get; set; }

        [JsonProperty("snooze_start_ts")]
        public string SnoozeStartTs { get; set; }

        [JsonProperty("snooze_end_ts")]
        public string SnoozeEndTs { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("push_sound")]
        public string PushSound { get; set; }
    }
}
