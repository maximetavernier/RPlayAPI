using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class PlaylistInfo : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }
    }
}