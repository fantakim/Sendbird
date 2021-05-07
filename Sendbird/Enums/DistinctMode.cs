using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DistinctMode
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "distinct")]
        Distinct,

        [EnumMember(Value = "nondistinct")]
        Nondistinct,
    }
}
