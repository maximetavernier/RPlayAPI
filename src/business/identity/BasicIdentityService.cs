using System;
using RPlay.Core.Extensions;
using RPlay.Core.Tools;
using RPlay.DTO.Authentication;

namespace RPlay.Business.Services.Users
{
    public sealed class BasicIdentityService : IdentityService<BasicIdentity>
    {
        #region Client Singleton
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static Lazy<BasicIdentityService> _instance;
        /// <summary>
        /// Get instance
        /// </summary>
        public static BasicIdentityService Instance
        {
            get
            {
                if (_instance == null || !_instance.IsValueCreated)
                    _instance = new Lazy<BasicIdentityService>(() => new BasicIdentityService());
                return _instance.Value;
            }
        }

        private BasicIdentityService()
        {
        }
        #endregion

        public BasicIdentity TryParse(Identity identity)
        {
            var id = EncodingTool.Base64Decode(identity.Token).FromBytesToString().Split(':');

            return id?.Length == 2 ? new BasicIdentity {
                Email = id[0],
                Password = id[1],
                Token = identity.Token,
                Method = identity.Method
            } : null;
        }
    }
}