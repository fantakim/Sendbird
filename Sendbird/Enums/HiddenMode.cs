using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;


namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HiddenMode
    {
        [EnumMember(Value = "unhidden_only")]
        UnhiddenOnly,

        [EnumMember(Value = "hidden_only")]
        HiddenOnly,

        [EnumMember(Value = "hidden_allow_auto_unhide")]
        HiddenAllowAutoUnhide,

        [EnumMember(Value = "hidden_prevent_auto_unhide")]
        HiddenPreventAutoUnhide,
    }
}
