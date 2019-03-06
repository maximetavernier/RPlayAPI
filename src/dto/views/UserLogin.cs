using Newtonsoft.Json;

namespace RPlay.DTO.Views
{
    [JsonObject]
    public sealed class UserLoginView : DBModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}