using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class RefLang : DBModel
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}