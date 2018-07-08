using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class AbstractUser : DBModel
    {
        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }
    }
}