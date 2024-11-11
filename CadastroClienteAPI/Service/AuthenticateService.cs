using Core.Account;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly CadastroContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(CadastroContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool Authenticate(string email, string senha)
        {
            var usuario = _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            if (usuario == null)
                return false;

            using var hmac = new HMACSHA512(usuario.SaltSenha);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.HashSenha[i])
                    return false;
            }

            return true;
        }

        public string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(60);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Usuario GetUserByEmail(string email)
        {
            return _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public bool UserExists(string email)
        {
            var usuario = _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            if (usuario == null)
                return false;

            return true;
        }
    }
}
