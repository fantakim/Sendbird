using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Core
{
    public class SendbirdClient : IClient
    {
        public static string DefaultApiBase => "https://api-{0}.sendbird.com/";

        public string AppId { get; }

        public string ApiToken { get; }

        public string ApiVersion { get; set; }

        public string ApiBase { get; }

        public IHttpClient HttpClient { get; }

        public SendbirdClient(
            string appId = null,
            string apiToken = null,
            string apiVersion = null,
            IHttpClient httpClient = null
            )
        {
            if (string.IsNullOrWhiteSpace(appId))
                throw new ArgumentException("AppId cannot be the empty.", nameof(appId));

            if (string.IsNullOrWhiteSpace(apiToken))
                throw new ArgumentException("ApiToken cannot be the empty.", nameof(apiToken));

            if (string.IsNullOrWhiteSpace(apiVersion))
                throw new ArgumentException("ApiVersion cannot be the empty.", nameof(apiVersion));

            this.AppId = appId;
            this.ApiToken = apiToken;
            this.ApiVersion = apiVersion;
            this.ApiBase = string.Format(DefaultApiBase, this.AppId);
            this.HttpClient = httpClient ?? BuildDefaultHttpClient();
        }

        public async Task<T> RequestAsync<T>(
            HttpMethod method, 
            string path, 
            BaseOptions options, 
            RequestOptions requestOptions, 
            CancellationToken cancellationToken = default
            ) where T : IEntity
        {
            var request = new SendbirdRequest(this, method, path, options, requestOptions);
            var response = await this.HttpClient.MakeRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return ProcessResponse<T>(response);
        }

        private static IHttpClient BuildDefaultHttpClient()
        {
            return new SystemNetHttpClient();
        }

        private static T ProcessResponse<T>(SendbirdResponse response) where T : IEntity
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw BuildSendbirdException(response);
            }

            T obj;
            try
            {
                obj = SendbirdEntity.FromJson<T>(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                throw BuildInvalidResponseException(response);
            }

            obj.Response = response;

            return obj;
        }

        private static SendbirdException BuildSendbirdException(SendbirdResponse response)
        {
            JObject jObject = null;

            try
            {
                jObject = JObject.Parse(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return BuildInvalidResponseException(response);
            }

            var error = jObject["error"];
            if (error == null)
            {
                return BuildInvalidResponseException(response);
            }

            var sendbirdError = jObject.ToObject<SendbirdError>();
            sendbirdError.Response = response;

            return new SendbirdException(
                response.StatusCode,
                sendbirdError,
                sendbirdError.Message)
            {
                Response = response,
            };
        }

        private static SendbirdException BuildInvalidResponseException(SendbirdResponse response)
        {
            return new SendbirdException(
                response.StatusCode,
                null,
                $"Invalid response object from API: \"{response.Content}\"")
            {
                Response = response,
            };
        }
    }
}
