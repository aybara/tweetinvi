using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tweetinvi.Models.Entities;
using Tweetinvi.Logic.JsonConverters;

namespace Tweetinvi.Logic.TwitterEntities
{
    public class ObjectEntitiesDTO : IObjectEntities
    {
        [JsonProperty("urls")]
        [JsonConverter(typeof(JsonPropertyConverterRepository))]
        public List<IUrlEntity> Urls { get; set; }

        [JsonProperty("user_mentions")]
        [JsonConverter(typeof(JsonPropertyConverterRepository))]
        public List<IUserMentionEntity> UserMentions { get; set; }

        [JsonProperty("hashtags")]
        [JsonConverter(typeof(JsonPropertyConverterRepository))]
        public List<IHashtagEntity> Hashtags { get; set; }

        [JsonProperty("symbols")]
        [JsonConverter(typeof(JsonPropertyConverterRepository))]
        public List<ISymbolEntity> Symbols { get; set; }

        [JsonProperty("media")]
        [JsonConverter(typeof(JsonPropertyConverterRepository))]
        public List<IMediaEntity> Medias { get; set; }
    }
}