using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PublicMode
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "private")]
        Private,

        [EnumMember(Value = "public")]
        Public,
    }
}
