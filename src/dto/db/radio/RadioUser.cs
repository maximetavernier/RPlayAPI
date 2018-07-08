using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class RadioUser : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("radio_id")]
        public Guid RadioId { get; set; }

        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
    }
}