using System;
using RPlay.DTO.Authentication;

namespace RPlay.Business.Services.Users
{
    public sealed class BearerIdentityService : IdentityService<BearerIdentity>
    {
        #region Client Singleton
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static Lazy<BearerIdentityService> _instance;
        /// <summary>
        /// Get instance
        /// </summary>
        public static BearerIdentityService Instance
        {
            get
            {
                if (_instance == null || !_instance.IsValueCreated)
                    _instance = new Lazy<BearerIdentityService>(() => new BearerIdentityService());
                return _instance.Value;
            }
        }

        private BearerIdentityService()
        {
        }
        #endregion

        public BearerIdentity TryParse(Identity identity)
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