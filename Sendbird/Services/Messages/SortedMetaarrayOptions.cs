using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Infrastructure;
using System.Collections.Generic;

namespace Sendbird.Services.Messages
{
    public class SortedMetaarrayOptions : BaseOptions
    {
        [JsonProperty("sorted_metaarray")]
        [JsonConverter(typeof(KeyValueDictionaryConverter))]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
