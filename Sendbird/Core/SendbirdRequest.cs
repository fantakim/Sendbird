using Sendbird.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sendbird.Core
{
    public class SendbirdRequest
    {
        private readonly BaseOptions options;

        public SendbirdRequest(
            IClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.options = options;

            this.Method = method;

            this.Uri = BuildUri(client, method, path, options, requestOptions);

            this.AuthorizationHeader = BuildAuthorizationHeader(client, requestOptions);

            this.SendbirdHeaders = BuildSendbirdHeaders(method, requestOptions);
        }

        public HttpMethod Method { get; }

        public Uri Uri { get; }

        public AuthenticationHeaderValue AuthorizationHeader { get; }

        public IDictionary<string, string> SendbirdHeaders { get; }

        public HttpContent Content => BuildContent(this.Method, this.options);

        public override string ToString()
        {
            return string.Format(
                "<{0} Method={1} Uri={2}>",
                this.GetType().FullName,
                this.Method,
                this.Uri.ToString());
        }

        private static Uri BuildUri(
            IClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            var b = new StringBuilder();

            b.Append(requestOptions.BaseUrl);
            b.Append(client.ApiVersion);
            b.Append(path);

            if ((method == HttpMethod.Get) && (options != null))
            {
                var queryString = FormEncoder.CreateQueryString(options);
                if (!string.IsNullOrEmpty(queryString))
                {
                    b.Append("?");
                    b.Append(queryString);
                }
            }

            return new Uri(b.ToString());
        }

        private static AuthenticationHeaderValue BuildAuthorizationHeader(
            IClient client,
            RequestOptions requestOptions)
        {
            string appId = requestOptions?.AppId ?? client.AppId;

            if (appId == null)
            {
                var message = "No AppId provided.";
                throw new SendbirdException(message);
            }

            var apiToken = requestOptions?.ApiToken ?? client.ApiToken;
            if (apiToken == null)
            {
                var message = "No Api Token provided.";
                throw new SendbirdException(message);
            }

            if (!string.IsNullOrEmpty(requestOptions.AccessToken))
            {
                return new AuthenticationHeaderValue("Basic", requestOptions.AccessToken);
            }

            return null;
        }

        private static Dictionary<string, string> BuildSendbirdHeaders(
            HttpMethod method,
            RequestOptions requestOptions)
        {
            var headers = new Dictionary<string, string>
            {
                { "Api-Token", requestOptions?.ApiToken ?? SendbirdConfiguration.ApiToken }
            };

            if (!string.IsNullOrEmpty(requestOptions?.IdempotencyKey))
            {
                headers.Add("Idempotency-Key", requestOptions.IdempotencyKey);
            }
            else if (method == HttpMethod.Post)
            {
                headers.Add("Idempotency-Key", Guid.NewGuid().ToString());
            }

            return headers;
        }

        private static HttpContent BuildContent(HttpMethod method, BaseOptions options)
        {
            if (method == HttpMethod.Get)
            {
                return null;
            }

            return FormEncoder.CreateHttpContent(options);
        }
    }
}
