using Newtonsoft.Json;

namespace Sendbird.Core
{
    [JsonObject]
    public class SendbirdList<T> : SendbirdEntity<SendbirdList<T>>, IHasObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }
    }
}
