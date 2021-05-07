using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sendbird.Infrastructure
{
    public class DateTimeConverter : DateTimeConverterBase
    {
        private TimestampSize _dateTimeValueUnits;

        public DateTimeConverter()
        {
            _dateTimeValueUnits = TimestampSize.Seconds;
        }

        public DateTimeConverter(TimestampSize dateTimeValueUnits)
        {
            _dateTimeValueUnits = dateTimeValueUnits;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteRawValue(((DateTime)value).ToEpoch(_dateTimeValueUnits).ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                if ((long)reader.Value == 0)
                {
                    return null;
                }

                if (_dateTimeValueUnits == TimestampSize.Milliseconds)
                {
                    return EpochTime.ToDateTime((long)reader.Value, _dateTimeValueUnits);
                }

                return EpochTime.ToDateTime((long)reader.Value);
            }

            return DateTime.Parse(reader.Value.ToString());
        }
    }
}
