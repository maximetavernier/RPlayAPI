using Newtonsoft.Json;

namespace RPlay.DTO.Options
{
    [JsonObject]
    public sealed class DBOptions
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("pooling")]
        public bool Pooling { get; set; }
    }
}