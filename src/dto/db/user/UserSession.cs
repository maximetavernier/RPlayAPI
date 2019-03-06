using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class UserSession : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("abstract_id")]
        public Guid AbstractId { get; set; }

        [JsonProperty("started")]
        public DateTime Started { get; set; }

        [JsonProperty("closed")]
        public DateTime? Closed { get; set; }
    }
}