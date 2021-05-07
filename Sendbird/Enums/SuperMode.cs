using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SuperMode
    {
        [EnumMember(Value = "nonsuper")]
        NonSuper,

        [EnumMember(Value = "super")]
        Super,

        [EnumMember(Value = "all")]
        All,
    }
}
