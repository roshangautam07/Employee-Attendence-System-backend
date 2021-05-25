using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dotnet.Helper
{
    public class TokenUtils
    {
        private IConfiguration _config = null;
        private string _securityKey = "";
        private string _issuer = "";
        private string _audience = "";

        public TokenUtils(IConfiguration _config)
        {
            this._config = _config;
            _securityKey = _config["Token:SecurityKey"];
            _issuer = _config["Token:Issuer"];
            _audience=_config["Token:Audience"];
        }
        public  string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("Issuer", "Roshan"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken(_issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}