using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class RefCountry : DBModel
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("code")]
        public short Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}