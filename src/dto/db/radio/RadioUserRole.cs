using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class RadioUserRole : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("radio_user_id")]
        public Guid RadioUserId { get; set; }

        [JsonProperty("role_id")]
        public Guid RoleId { get; set; }
    }
}