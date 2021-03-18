using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartLocker.WebAPI.Contracts.DTOs.Internal;
using SmartLocker.WebAPI.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartLocker.WebAPI.Services
{
    public class JwtTokenService
    {
        private readonly JwtOptions jwtOptions;

        public JwtTokenService(IOptions<JwtOptions> jwtOptions) => (this.jwtOptions) = (jwtOptions.Value);

        public JwtSecurityToken CreateJwtSecurityToken(UserIdentity identity)
        {
            var now = DateTime.UtcNow;

            var JWTToken = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                notBefore: now,
                claims: GetClaims(identity),
                expires: now.Add(TimeSpan.FromMinutes(jwtOptions.LifeTime)),
                signingCredentials: new SigningCredentials(
                    key: jwtOptions.GetSymmetricSecurityKey(),
                    algorithm: SecurityAlgorithms.HmacSha256)
            );
            return JWTToken;
        }

        public string EncodeJwtSecurityToken(JwtSecurityToken token) =>
            new JwtSecurityTokenHandler().WriteToken(token);

        private IEnumerable<Claim> GetClaims(UserIdentity identity) =>
            new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, identity.Id.ToString()),
                new (ClaimsIdentity.DefaultRoleClaimType, identity.Role),
            };
    }
}
