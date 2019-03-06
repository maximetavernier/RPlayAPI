using Newtonsoft.Json;

namespace RPlay.DTO.Options
{
    [JsonObject]
    public sealed class JWTOptions
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }
    }
}