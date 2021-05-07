namespace Sendbird.Core
{
    public class RequestOptions
    {
        public string AppId { get; set; }

        public string ApiToken { get; set; }

        internal string ApiVersion { get; set; }

        public string IdempotencyKey { get; set; }

        public string AccessToken { get; set; }

        internal string BaseUrl { get; set; }
    }
}
