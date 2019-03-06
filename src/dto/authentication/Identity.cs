using System;
using Newtonsoft.Json;

namespace RPlay.DTO.Authentication
{
    [JsonObject]
    public class Identity
    {
        [JsonIgnore]
        public AuthenticationMethod Method { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}