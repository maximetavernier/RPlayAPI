using System;
using RPlay.Core.Tools;
using RPlay.DTO.Authentication;

namespace RPlay.Business.Services.Users
{
    public sealed class FacebookIdentityService : IdentityService<FacebookIdentity>
    {
        #region Client Singleton
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static Lazy<FacebookIdentityService> _instance;
        /// <summary>
        /// Get instance
        /// </summary>
        public static FacebookIdentityService Instance
        {
            get
            {
                if (_instance == null || !_instance.IsValueCreated)
                    _instance = new Lazy<FacebookIdentityService>(() => new FacebookIdentityService());
                return _instance.Value;
            }
        }

        private FacebookIdentityService()
        {
        }
        #endregion

        public FacebookIdentity TryParse(Identity identity)
        {
            /*
            var id = EncodingTool.Base64Decode(identity.Token).FromBytesToString().Split(':');

            return id?.Length == 2 ? new BasicIdentity {
                Email = id[0],
                Password = id[1],
                Token = identity.Token,
                Method = identity.Method
            } : null;
            */
            return null;
        }
    }
}