using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using RPlay.Core.Tools;
using RPlay.DTO.Authentication;
using RPlay.DTO.DB;
using RPlay.DTO.Options;
using RPlay.DTO.Views;

namespace RPlay.Business.Services.Users
{
    public sealed class UserService : Service
    {
        private readonly AuthService _authService;
        public UserService(IConfiguration configuration) : base(configuration.GetSection("DB").Get<DBOptions>())
        {
            _authService = new AuthService(configuration.GetSection("Auth").Get<AuthOptions>());
        }

        public List<PlatformUser> GetAll()
        {
            return connection.GetAll<PlatformUser>();
        }

        public bool ValidateAuthentication(Identity identity)
        {
            var query = new StringBuilder("select pu.abstract_id as Id, l.login as Login, p.hash as Hash from platform_user pu ")
                              .AppendLine("join user_login l on pu.abstract_id = l.user_id")
                              .AppendLine("join shadow_passwd p on pu.abstract_id = p.user_id")
                              .AppendLine($"where pu.email = '{identity.Email}'")
                              .ToString();
            var result = connection.Query<UserPasswordView>(query).FirstOrDefault();
            if (result == null)
                return false;

            var computed = _authService.ComputePassword(result.Id, result.Login, identity.Password);
            return result.Hash.Equals(computed);
        }

        public UserLoginView GetUserByEmail(string email)
        {
            var query = new StringBuilder("select au.id as Id, l.login as Login from abstract_user au ")
                              .AppendLine("join user_login l on au.id = l.user_id")
                              .AppendLine($"where u.email = '{email}'")
                              .ToString();
            return connection.Query<UserLoginView>(query).FirstOrDefault();
        }

        public void StartSession(Identity identity)
        {
            var query = $"select * from abstract_user au where au.id = '{identity.Id}'";
            var abstractUser = connection.Query<AbstractUser>(query).FirstOrDefault();

            if (abstractUser != default (AbstractUser)) {
                var now = DateTime.Now;
                var metadata = new Metadata {
                    Id = new Guid(),
                    CreationUserId = abstractUser.Id,
                    CreationDate = now
                };
                var session = new UserSession {
                    Id = new Guid(),
                    MetadataId = metadata.Id,
                    AbstractId = abstractUser.Id,
                    Started = now
                };
                connection.PostAsync(metadata).ConfigureAwait(false);
                connection.PostAsync(session).ConfigureAwait(false);
            }
        }

        public void CloseSession(Identity identity)
        {
            throw new NotImplementedException();
        }
    }
}