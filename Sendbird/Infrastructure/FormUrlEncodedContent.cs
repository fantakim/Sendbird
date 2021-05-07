using Newtonsoft.Json;
using Sendbird.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sendbird.Infrastructure
{
    internal class FormUrlEncodedContent : ByteArrayContent
    {
        public FormUrlEncodedContent(BaseOptions options) 
            : base(CreateContentByteArray(options))
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.ContentType.CharSet = "utf-8";
        }

        public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
            : base(CreateContentByteArray(nameValueCollection))
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            this.Headers.ContentType.CharSet = "utf-8";
        }

        private static byte[] CreateContentByteArray(BaseOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var json = JsonConvert.SerializeObject(options, Formatting.None, 
                new JsonSerializerSettings 
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            );

            return Encoding.UTF8.GetBytes(json);
        }

        private static byte[] CreateContentByteArray(
            IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException(nameof(nameValueCollection));
            }

            return Encoding.UTF8.GetBytes(FormEncoder.CreateQueryString(nameValueCollection));
        }
    }
}
