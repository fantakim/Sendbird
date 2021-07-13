using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using System.Collections.Generic;

namespace Sendbird.Services.Messages
{
    public class MessageList : SendbirdList<TextMessage>
    {
        [JsonProperty("messages")]
        public List<TextMessage> Messages { get; set; }
    }
}
