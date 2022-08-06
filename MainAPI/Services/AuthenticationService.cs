using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MainAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace MainAPI.Services
{
    public class AuthenticationService
    {
        private readonly byte[] _key;

        public AuthenticationService(byte[] key)
        {
            _key = key;
        }

        public string Authenticate(string email, string password, Role role)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = _key;
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role.roleName)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}