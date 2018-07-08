using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class User : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("abstract_id")]
        public Guid AbstractId { get; set; }

        [JsonProperty("locale_id")]
        public Guid LocaleId { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("gender")]
        public bool Gender { get; set; }
        
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }
    }
}