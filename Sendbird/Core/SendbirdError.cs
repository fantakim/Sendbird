using Newtonsoft.Json;
using Sendbird.Enums;
using System;

namespace Sendbird.Core
{
    public class SendbirdError : SendbirdEntity<SendbirdError>
    {
        [JsonProperty("error")]
        public bool IsError { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        public ErrorCode? ErrorCode
        {
            get
            {
                if (Enum.TryParse($"{this.Code}", out ErrorCode errorCode))
                    return errorCode;

                return null;
            }
        }
    }
}
