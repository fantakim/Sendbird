using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "MESG")]
        Message,

        [EnumMember(Value = "ADMM")]
        AdminMessage,

        [EnumMember(Value = "FILE")]
        File,
    }
}
