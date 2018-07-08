using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class RadioSettings : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("radio_id")]
        public Guid RadioId { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }
    }
}