﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Tweetinvi.Models.Entities;

namespace Tweetinvi.Logic.TwitterEntities
{
    public class ObjectEntitiesDTO : IObjectEntities
    {
        [JsonProperty("urls")]
        [JsonConverter(typeof())]
        public List<IUrlEntity> Urls { get; set; }

        [JsonProperty("user_mentions")]
        public List<IUserMentionEntity> UserMentions { get; set; }

        [JsonProperty("hashtags")]
        public List<IHashtagEntity> Hashtags { get; set; }

        [JsonProperty("symbols")]
        public List<ISymbolEntity> Symbols { get; set; }

        [JsonProperty("media")]
        public List<IMediaEntity> Medias { get; set; }
    }
}