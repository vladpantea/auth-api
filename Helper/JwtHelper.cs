using Auth.API.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.API.Helper
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IJwtSettings _settings;
        public JwtHelper(IJwtSettings settings)
        {
            _settings = settings;
        }

        public string Sign(string username)
        {
            var payload = new Dictionary<string, string>();
            payload.Add("username", username);
            var secret = _settings.Secret;
            var audience = _settings.Audience;
            var issuer = _settings.Issuer;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
                Issuer = issuer,
                Audience = audience
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }

    public interface IJwtHelper 
    {
        public string Sign(string username);
    }
}
