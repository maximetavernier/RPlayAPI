using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class Metadata : DBModel
    {
        [JsonProperty("creation_user_id")]
        public Guid CreationUserId { get; set; }

        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("update_user_id")]
        public Guid UpdateUserId { get; set; }

        [JsonProperty("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}