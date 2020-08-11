using huyblog.Models.ModelResult;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace huyblog.Services.JWT
{
    public class JWTService
    {
        private readonly string _secret;
        private readonly string _expDate;

        public JWTService(IConfiguration config)
        {
            _secret = config["JwtConfig:Secret"];
            _expDate = config["JwtConfig:ExpInMinutes"];
        }

        public LoginResult GenerateSecurityToken(string email)
        {
            var objToken = new LoginResult();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            objToken.Token = tokenHandler.WriteToken(token);
            objToken.Expires = _expDate;

            return objToken;
        }
    }
}
