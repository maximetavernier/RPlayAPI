using Newtonsoft.Json;

namespace RPlay.DTO.Options
{
    [JsonObject]
    public sealed class AuthOptions
    {
        [JsonProperty("Jwt")]
        public JWTOptions Jwt { get; set; }
    }
}