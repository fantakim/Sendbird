using Newtonsoft.Json;
using Sendbird.Core;
using System.Collections.Generic;

namespace Sendbird.Entities
{
    public class SortedMetaarray : SendbirdEntity<SortedMetaarray>
    {
        [JsonProperty("sorted_metaarray")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
