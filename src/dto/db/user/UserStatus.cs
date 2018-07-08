using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class UserStatus : DBModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_radio")]
        public bool IsRadio { get; set; }

        [JsonProperty("is_salon")]
        public bool IsSalon { get; set; }
    }
}