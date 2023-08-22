using basicwebapi.constants;
using basicwebapi.Models;
using BasicWebApi.IService.IService;
using BasicWebApi.ViewModel.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        /// <summary>
        /// this method is used to generate refresh token so that it is used to get new access token
        /// Usually the refresh token is given long expiration time than access token to avoid illegal usage of access tokens
        /// for accessing  the secured end points
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Utilities.EncodeToBase64(valuebytes: randomNumber);
            }

        }
        /// <summary>
        /// this method is used to generate access token(Jwt token) which is short lived .
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public string generatetoken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var audience = _configuration["Jwt:Audience"];
            var issuer = _configuration["Jwt:Issuer"];
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Utilities.INDIAN_ZONE).AddMinutes(1),
                signingCredentials: credentials
                   );


            var tokenToRet = new JwtSecurityTokenHandler().WriteToken(token);


            return tokenToRet;
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            var secret = _configuration["Jwt:key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            SecurityToken securityToken;

            claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidateActor = false,
                RequireExpirationTime = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),

            }, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                claimsPrincipal = null;
                return claimsPrincipal;
            }

            return claimsPrincipal;


        }

    }
}
