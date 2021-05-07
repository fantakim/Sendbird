using Newtonsoft.Json;
using Sendbird.Core;
using Sendbird.Infrastructure;
using System.Collections.Generic;

namespace Sendbird
{
    public static class SendbirdConfiguration
    {
        private static int maxNetworkRetries;

        private static IClient sendbirdClient;

        static SendbirdConfiguration()
        {
        }

        public static string AppId { get; set; }

        public static string ApiToken { get; set; }

        public static string ApiVersion => "v3";

        public static JsonSerializerSettings SerializerSettings { get; set; } = DefaultSerializerSettings();

        public static int MaxNetworkRetries
        {
            get => maxNetworkRetries;

            set
            {
                if (value != maxNetworkRetries)
                {
                    Client = null;
                }

                maxNetworkRetries = value;
            }
        }

        public static IClient Client
        {
            get
            {
                if (sendbirdClient == null)
                {
                    sendbirdClient = BuildDefaultSendbirdClient();
                }

                return sendbirdClient;
            }

            set => sendbirdClient = value;
        }

        public static JsonSerializerSettings DefaultSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new SendbirdObjectConverter(),
                },
                DateParseHandling = DateParseHandling.None,
            };
        }

        public static void SetAppId(string appId)
        {
            AppId = appId;
        }

        public static void SetApiToken(string apiToken)
        {
            ApiToken = apiToken;
        }

        private static SendbirdClient BuildDefaultSendbirdClient()
        {
            if (AppId != null && AppId.Length == 0)
            {
                var message = "Your AppId is invalid, as it is an empty string.";
                throw new SendbirdException(message);
            }

            if (AppId != null && StringUtils.ContainsWhitespace(AppId))
            {
                var message = "Your AppId is invalid, as it contains whitespace.";
                throw new SendbirdException(message);
            }

            var httpClient = new SystemNetHttpClient(
                httpClient: null,
                maxNetworkRetries: MaxNetworkRetries
                );

            return new SendbirdClient(AppId, ApiToken, ApiVersion, httpClient);
        }
    }
}
