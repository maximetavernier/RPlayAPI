using System;
using Newtonsoft.Json;

namespace RPlay.DTO.Views
{
    [JsonObject]
    public sealed class UserPasswordView : DBModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}