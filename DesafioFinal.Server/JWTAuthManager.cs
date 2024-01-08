using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioFinal.Server
{
    public interface IJWTAuthManager
    {
        string Authenticate(string username, string password, HospitalContext context);
    }

    public class JWTAuthManager : IJWTAuthManager
    {
        private readonly string _tokenKey;

        public JWTAuthManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public string Authenticate(string username, string password, HospitalContext context)
        {
            Login login = context.Logins.FirstOrDefault(log => log.Username == username && log.Password == password);
            if (login == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddSeconds(12),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}