using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tweetinvi.Logic.JsonConverters
{
    public interface IJsonInterfaceToObjectConverter
    {
        Type InterfaceType { get; }
    }

    public class JsonInterfaceToObjectConverter<T, U> : JsonConverter, IJsonInterfaceToObjectConverter
        where U : T
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<U>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            var canConvert = objectType == typeof (T);
            return canConvert;
        }

        public Type InterfaceType
        {
            get { return typeof (T); }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}