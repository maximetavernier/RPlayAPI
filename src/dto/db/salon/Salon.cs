using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class Salon : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("radio_id")]
        public Guid RadioId { get; set; }

        [JsonProperty("playlist_id")]
        public Guid PlaylistId { get; set; }

        [JsonProperty("owner_id")]
        public Guid OwnerId { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}