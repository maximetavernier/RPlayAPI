using Newtonsoft.Json;

namespace RPlay.DTO.Authentication
{
    [JsonObject]
    public sealed class BasicIdentity : Identity
    {
        public BasicIdentity()
        {
            Method = AuthenticationMethod.BASIC;
        }
    }
}