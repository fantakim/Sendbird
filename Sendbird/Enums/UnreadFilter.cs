using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnreadFilter
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "unread_message")]
        UnreadMessage,
    }
}
