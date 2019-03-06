using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RPlay.Core.Extensions;
using RPlay.Core.Tools;
using RPlay.DTO.Authentication;
using RPlay.DTO.Options;

namespace RPlay.Business.Services.Users
{
    public sealed class AuthService
    {
        #region Configs
        private readonly AuthOptions _options;
        #endregion

        #region Constants
        private const double DefaultExpirationTime = 60 * 24;
        #endregion

        public AuthService(AuthOptions options)
        {
            _options = options;
        }

        public Identity Authenticate(string token)
        {
            var id = new Identity {
                Method = token.StartsWith("Basic ") ? AuthenticationMethod.BASIC
                       : token.StartsWith("Facebook ") ? AuthenticationMethod.FACEBOOK
                       : AuthenticationMethod.BEARER,
                Token = token.ReplaceAll(new List<string>{ "Basic ", "Facebook ", "Bearer " }, string.Empty)
            };
            switch(id.Method) {
                case AuthenticationMethod.BASIC:
                    id = BasicIdentityService.Instance.TryParse(id);
                    break;
                case AuthenticationMethod.FACEBOOK:
                    id = FacebookIdentityService.Instance.TryParse(id);
                    break;
                default: // Bearer
                    id = BearerIdentityService.Instance.TryParse(id);
                    break;
            }

            return id;
        }

        public string CreateAuthToken(Identity identity)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.CHash, identity.Password),
                new Claim(JwtRegisteredClaimNames.Email, identity.Email),
                new Claim(JwtRegisteredClaimNames.NameId, identity.Id.ToString())
            };

            var key = new SymmetricSecurityKey(EncodingTool.UTF8.GetBytes(_options.Jwt.Key));
            var token = new JwtSecurityToken(_options.Jwt.Issuer,_options.Jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(DefaultExpirationTime),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ComputePassword(Guid id, string login, string password)
        {
            var salt = CryptoTool.EncryptMD5(EncodingTool.UCS2.GetBytes($"{id.ToString().Substring(0, 8)}{id.ToString().Substring(23, 12)}"));
            var hash = EncodingTool.UTF8.GetBytes(login).Concat(salt).Concat(EncodingTool.UTF16.GetBytes(password));

            var result = EncodingTool.UTF8.GetString(CryptoTool.EncryptSha256(hash));
            return result;
        }
    }
}