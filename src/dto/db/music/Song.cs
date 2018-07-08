using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class Song : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artiste")]
        public string Artiste { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}