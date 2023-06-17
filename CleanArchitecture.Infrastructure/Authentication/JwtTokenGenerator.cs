﻿using CleanArchitecture.Application.Interfaces.Authentication;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            #region 1.Yöntem
            //var signingCredeantials = new SigningCredentials(
            //   new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
            //   SecurityAlgorithms.HmacSha256
            //   );

            #endregion

            var signingCredeantials = new SigningCredentials(
               new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
               SecurityAlgorithms.HmacSha256
               );


            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };


            #region 1.Yöntem
            //var securityToken = new JwtSecurityToken(
            //    issuer: "CleanArchitecture",
            //    expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            //    claims: claims,
            //    signingCredentials: signingCredeantials
            //    );
            #endregion


            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
                claims: claims,
                signingCredentials: signingCredeantials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
