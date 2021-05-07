using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sendbird.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderMode
    {
        [EnumMember(Value = "chronological")]
        Chronological,

        [EnumMember(Value = "latest_last_message")]
        LatestLastMessage,

        [EnumMember(Value = "channel_name_alphabetical")]
        ChannelNameAlphabetical,

        [EnumMember(Value = "metadata_value_alphabetical")]
        MetadataValueAlphabetical,
    }
}
