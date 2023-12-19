using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioFinal.Server
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string nome, string email, string senha);
    }

    public class JWTAuthManager : IJWTAuthenticationManager
    {
        private readonly HospitalContext _context;
        private readonly string _tokenKey;
        
        public JWTAuthManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public JWTAuthManager(string tokenKey, HospitalContext context)
        {
            _context = context;
            _tokenKey = tokenKey;
        }

        public string Authenticate(string nome, string email, string senha)
        {
            List<Login> logins = _context.Logins.ToList();
            
            if (!logins.Any(login => login.Email == email || login.Nome == nome && login.Senha == senha))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Email, email)
                    // Não é recomendado guardar a senha no JWT
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
