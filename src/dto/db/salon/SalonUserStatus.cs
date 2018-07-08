using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class SalonUserStatus : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("radio_user_id")]
        public Guid RadioUserId { get; set; }

        [JsonProperty("status_id")]
        public Guid StatusId { get; set; }
    }
}