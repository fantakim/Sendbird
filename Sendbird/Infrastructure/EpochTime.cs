using System;

namespace Sendbird.Infrastructure
{
    internal static class EpochTime
    {
        private static DateTime epochStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(long seconds, TimestampSize timestampSize = TimestampSize.Seconds)
        {
            if (timestampSize == TimestampSize.Milliseconds)
            {
                return epochStartDateTime.AddMilliseconds(seconds);
            }

            return epochStartDateTime.AddSeconds(seconds);
        }

        public static long ToEpoch(this DateTime datetime, TimestampSize timestampSize = TimestampSize.Seconds)
        {
            if (datetime < epochStartDateTime)
            {
                return 0;
            }

            if (timestampSize == TimestampSize.Milliseconds)
            {
                return Convert.ToInt64((datetime.ToUniversalTime() - epochStartDateTime).TotalMilliseconds);
            }

            return Convert.ToInt64((datetime.ToUniversalTime() - epochStartDateTime).TotalSeconds);
        }
    }
}
