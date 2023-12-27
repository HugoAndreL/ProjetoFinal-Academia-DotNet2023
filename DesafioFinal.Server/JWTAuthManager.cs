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
        private readonly string _tokenKey;

        public JWTAuthManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public string Authenticate(string username, string password)
        {
            if (username == null || password == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
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