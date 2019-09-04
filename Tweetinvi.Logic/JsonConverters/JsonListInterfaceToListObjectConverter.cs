using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tweetinvi.Logic.JsonConverters
{
    public interface IJsonListInterfaceToListObjectConverter
    {
        Type ListInterfaceType { get; }
    }
    public class JsonListInterfaceToListObjectConverter<T, U> : JsonConverter, IJsonListInterfaceToListObjectConverter
        where U : T
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var objectsList = serializer.Deserialize<List<U>>(reader);
            var interfacesList = new List<T>();
            foreach (var obj in objectsList)
            {
                interfacesList.Add(obj);
            }
            return interfacesList;
        }

        public override bool CanConvert(Type objectType)
        {
            var canConvert = objectType == typeof(List<T>);
            return canConvert;
        }

        public Type ListInterfaceType
        {
            get { return typeof(Dictionary<string, T>); }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
