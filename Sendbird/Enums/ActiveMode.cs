using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActiveMode
    {
        [EnumMember(Value = "activated")]
        Activated,

        [EnumMember(Value = "deactivated")]
        Deactivated,

        [EnumMember(Value = "all")]
        All,
    }
}
