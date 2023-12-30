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
        string Authenticate(string username, string password);
    }

    public class JWTAuthManager : IJWTAuthManager
    {
        //private readonly HospitalContext _context = new();
        private readonly string _tokenKey;

        public JWTAuthManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public string Authenticate(string username, string password)
        {
            //Login login = _context.Logins.FirstOrDefault(log => log.Username == username && log.Password == password);

            //if (login == null)
            //    return null;

            JwtSecurityTokenHandler tokenHandler = new();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    // Não é recomendado guardar a senha no JWT
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}