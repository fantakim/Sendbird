using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sendbird.Infrastructure;

namespace Sendbird.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class SendbirdEntity : IEntity
    {
        [JsonIgnore]
        private JObject rawJObject;

        [JsonIgnore]
        public JObject RawJObject
        {
            get
            {
                if (this.rawJObject == null)
                {
                    if (this.Response == null)
                    {
                        return null;
                    }

                    this.rawJObject = JObject.Parse(this.Response.Content);
                }

                return this.rawJObject;
            }

            protected set
            {
                this.rawJObject = value;
            }
        }

        [JsonIgnore]
        public SendbirdResponse Response { get; set; }

        public static IHasObject FromJson(string value)
        {
            return JsonUtils.DeserializeObject<IHasObject>(value, SendbirdConfiguration.SerializerSettings);
        }

        public static T FromJson<T>(string value) where T : IEntity
        {
            return JsonUtils.DeserializeObject<T>(value, SendbirdConfiguration.SerializerSettings);
        }

        public override string ToString()
        {
            return string.Format(
                "<{0}@{1} id={2}> JSON: {3}",
                this.GetType().FullName,
                RuntimeHelpers.GetHashCode(this),
                this.GetIdString(),
                this.ToJson());
        }

        public string ToJson()
        {
            return JsonUtils.SerializeObject(
                this,
                Formatting.Indented,
                SendbirdConfiguration.SerializerSettings);
        }

        private object GetIdString()
        {
            foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties)
            {
                if (property.Name == "Id")
                {
                    return property.GetValue(this);
                }
            }

            return null;
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Generic variant")]
    public abstract class SendbirdEntity<T> : SendbirdEntity where T : SendbirdEntity<T>
    {
        public static new T FromJson(string value)
        {
            return SendbirdEntity.FromJson<T>(value);
        }
    }
}
