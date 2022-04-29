﻿using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration _configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration=configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user, List<OperationClaims> operationClaims, int companyId)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpression);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredentials = SigningCredentialsHelper.CreateSignInCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signinCredentials, operationClaims, companyId);
            var jwtSecurityTokenHAndler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHAndler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                CompanyId = companyId
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signInCrediantials, List<OperationClaims> operationClaims, int companyId)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims, companyId),
                signingCredentials: signInCrediantials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaims> operationClaims, int companyId)
        {
            var claims=new List<Claim>();
            claims.AddNameIdentityfier(user.UserId.ToString());
            claims.AddEmail(user.UserEmail);
            claims.AddName ($"{user.UserName}");
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            claims.AddCompany(companyId.ToString());
            return claims;
        }
    }
}
