using Newtonsoft.Json;

namespace RPlay.DTO.Authentication
{
    [JsonObject]
    public sealed class BearerIdentity : Identity
    {
        public BearerIdentity()
        {
            Method = AuthenticationMethod.BEARER;
        }
        
        [JsonProperty("exp")]
        public int Expiration { get; set; }
    }
}