using System;
using System.Net;

namespace Sendbird.Core
{
    public class SendbirdException : Exception
    {
        public SendbirdException()
        {
        }

        public SendbirdException(string message)
            : base(message)
        {
        }

        public SendbirdException(string message, Exception err)
            : base(message, err)
        {
        }

        public SendbirdException(HttpStatusCode httpStatusCode, SendbirdError error, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Error = error;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public SendbirdError Error { get; set; }

        public SendbirdResponse Response { get; set; }
    }
}
