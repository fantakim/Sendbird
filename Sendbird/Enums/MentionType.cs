using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MentionType
    {
        [EnumMember(Value = "users")]
        Users,

        [EnumMember(Value = "channel")]
        Channel,
    }
}
