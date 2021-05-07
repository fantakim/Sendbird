using Newtonsoft.Json;

namespace Sendbird.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseOptions : INestedOptions
    {
    }
}
