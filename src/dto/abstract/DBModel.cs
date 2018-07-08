using System;
using Newtonsoft.Json;

namespace RPlay.DTO
{
    [JsonObject]
    public abstract class DBModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}