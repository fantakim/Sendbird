using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MemberStateFilter
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "invited_only")]
        InvitedOnly,

        [EnumMember(Value = "joined_only")]
        JoinedOnly,

        [EnumMember(Value = "invited_by_friend")]
        InvitedByFriend,

        [EnumMember(Value = "invited_by_non_friend")]
        InvitedByNonFriend,
    }
}
