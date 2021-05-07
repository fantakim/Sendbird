using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sendbird.Core
{
    public class SendbirdObjectConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("SendbirdObjectConverter should only be used while deserializing.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jsonObject = JObject.Load(reader);
            var objectValue = (string)jsonObject["object"];

            Type concreteType = SendbirdTypeRegistry.GetConcreteType(objectType, objectValue);
            if (concreteType == null)
            {
                return null;
            }

            var value = Activator.CreateInstance(concreteType);

            using (var subReader = jsonObject.CreateReader())
            {
                serializer.Populate(subReader, value);
            }

            return value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsInterface;
        }
    }
}
