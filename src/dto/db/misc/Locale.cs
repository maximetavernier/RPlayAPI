using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class Locale : DBModel
    {
        [JsonProperty("lang_id")]
        public Guid LangId { get; set; }

        [JsonProperty("country_id")]
        public Guid CountryId { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }
    }
}