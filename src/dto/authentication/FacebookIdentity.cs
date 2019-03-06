using Newtonsoft.Json;

namespace RPlay.DTO.Authentication
{
    [JsonObject]
    public sealed class FacebookIdentity : Identity
    {
        public FacebookIdentity()
        {
            Method = AuthenticationMethod.FACEBOOK;
        }
    }
}