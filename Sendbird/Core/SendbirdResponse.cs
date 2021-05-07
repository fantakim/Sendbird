using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace Sendbird.Core
{
    public class SendbirdResponse
    {
        public SendbirdResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.Content = content;
        }

        public HttpStatusCode StatusCode { get; }

        public HttpResponseHeaders Headers { get; }

        public string Content { get; }

        public DateTimeOffset? Date => this.Headers?.Date;

        public string IdempotencyKey => MaybeGetHeader(this.Headers, "Idempotency-Key");

        public string RequestId => MaybeGetHeader(this.Headers, "Request-Id");

        internal int NumRetries { get; set; }

        public override string ToString()
        {
            return string.Format(
                "<{0} status={1} Request-Id={2} Date={3}>",
                this.GetType().FullName,
                (int)this.StatusCode,
                this.RequestId,
                this.Date?.ToString("s"));
        }

        private static string MaybeGetHeader(HttpHeaders headers, string name)
        {
            if ((headers == null) || (!headers.Contains(name)))
            {
                return null;
            }

            return headers.GetValues(name).First();
        }
    }
}
