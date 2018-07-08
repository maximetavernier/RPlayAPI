using System;
using Newtonsoft.Json;

namespace RPlay.DTO.DB
{
    [JsonObject]
    public sealed class SalonHistory : DBModel
    {
        [JsonProperty("metadata_id")]
        public Guid MetadataId { get; set; }

        [JsonProperty("salon_id")]
        public Guid SalonId { get; set; }

        [JsonProperty("song_id")]
        public Guid SongId { get; set; }

        [JsonProperty("added_by")]
        public Guid AddedBy { get; set; }

        [JsonProperty("added_date")]
        public DateTime AddedDate { get; set; }

        [JsonProperty("removed_date")]
        public DateTime RemovedDate { get; set; }
    }
}