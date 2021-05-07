using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Entities;
using System.Collections.Generic;

namespace Sendbird.Services.Users
{
    public class UserList : SendbirdList<User>
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
