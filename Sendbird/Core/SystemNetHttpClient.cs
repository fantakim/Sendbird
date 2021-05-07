using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Core
{
    public class SystemNetHttpClient : IHttpClient
    {
        private static readonly Lazy<HttpClient> LazyDefaultHttpClient = new Lazy<HttpClient>(BuildDefaultSystemNetHttpClient);

        private readonly HttpClient httpClient;

        private readonly object randLock = new object();

        private readonly Random rand = new Random();

        static SystemNetHttpClient()
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
        }

        public SystemNetHttpClient(
            HttpClient httpClient = null,
            int maxNetworkRetries = 0
            )
        {
            this.httpClient = httpClient ?? LazyDefaultHttpClient.Value;
            this.MaxNetworkRetries = maxNetworkRetries;
        }

        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(80);

        public static TimeSpan MaxNetworkRetriesDelay => TimeSpan.FromSeconds(5);

        public static TimeSpan MinNetworkRetriesDelay => TimeSpan.FromMilliseconds(500);

        public bool EnableTelemetry { get; }

        public int MaxNetworkRetries { get; }

        internal bool NetworkRetriesSleep { get; set; } = true;

        public static HttpClient BuildDefaultSystemNetHttpClient()
        {
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        }

        public async Task<SendbirdResponse> MakeRequestAsync(SendbirdRequest request, CancellationToken cancellationToken = default)
        {
            TimeSpan duration;
            Exception requestException = null;
            HttpResponseMessage response = null;
            int retry = 0;

            while (true)
            {
                requestException = null;

                var httpRequest = this.BuildRequestMessage(request);

                var stopwatch = Stopwatch.StartNew();

                try
                {
                    response = await this.httpClient.SendAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (HttpRequestException exception)
                {
                    requestException = exception;
                }
                catch (OperationCanceledException exception)
                    when (!cancellationToken.IsCancellationRequested)
                {
                    requestException = exception;
                }

                stopwatch.Stop();

                duration = stopwatch.Elapsed;

                if (!this.ShouldRetry(
                    retry,
                    requestException != null,
                    response?.StatusCode,
                    response?.Headers))
                {
                    break;
                }

                retry += 1;
                await Task.Delay(this.SleepTime(retry)).ConfigureAwait(false);
            }

            if (requestException != null)
            {
                throw requestException;
            }

            var reader = new StreamReader(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false));

            return new SendbirdResponse(
                response.StatusCode,
                response.Headers,
                await reader.ReadToEndAsync().ConfigureAwait(false))
            {
                NumRetries = retry,
            };
        }

        private bool ShouldRetry(
            int numRetries,
            bool error,
            HttpStatusCode? statusCode,
            HttpHeaders headers)
        {
            if (numRetries >= this.MaxNetworkRetries)
            {
                return false;
            }

            if (error == true)
            {
                return true;
            }

            if (headers != null && headers.Contains("Sendbird-Should-Retry"))
            {
                var value = headers.GetValues("Sendbird-Should-Retry").First();

                switch (value)
                {
                    case "true":
                        return true;
                    case "false":
                        return false;
                }
            }

            if (statusCode == HttpStatusCode.Conflict)
            {
                return true;
            }

            if (statusCode.HasValue && ((int)statusCode.Value >= 500))
            {
                return true;
            }

            return false;
        }

        private HttpRequestMessage BuildRequestMessage(SendbirdRequest request)
        {
            var requestMessage = new HttpRequestMessage(request.Method, request.Uri);
            requestMessage.Headers.Authorization = request.AuthorizationHeader;

            foreach (var header in request.SendbirdHeaders)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            requestMessage.Content = request.Content;

            return requestMessage;
        }

        private TimeSpan SleepTime(int numRetries)
        {
            if (!this.NetworkRetriesSleep)
            {
                return TimeSpan.Zero;
            }

            var delay = TimeSpan.FromTicks((long)(MinNetworkRetriesDelay.Ticks * Math.Pow(2, numRetries - 1)));
            if (delay > MaxNetworkRetriesDelay)
            {
                delay = MaxNetworkRetriesDelay;
            }

            var jitter = 1.0;
            lock (this.randLock)
            {
                jitter = (3.0 + this.rand.NextDouble()) / 4.0;
            }

            delay = TimeSpan.FromTicks((long)(delay.Ticks * jitter));

            if (delay < MinNetworkRetriesDelay)
            {
                delay = MinNetworkRetriesDelay;
            }

            return delay;
        }
    }
}
