using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class Playlist : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("info_id")]
        public Guid InfoId { get; set; }

        [JsonProperty("song_id")]
        public Guid SongId { get; set; }
    }
}