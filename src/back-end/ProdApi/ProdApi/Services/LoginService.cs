using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProdApi.Configurations;
using ProdApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ProdApi.Services
{
    public class LoginService
    {
        private readonly JwtSettings _jwt;

        public LoginService(IOptions<JwtSettings> jwtOptions)
        {
            _jwt = jwtOptions.Value;
        }

        private readonly List<Usuario> usuarios =
        [
            new Usuario
            {
                Login = "lenilson.junior",
                Senha = "2026",
                Nome = "Lenilson Junior"
            }
        ];

        public LoginResp Login(LoginRequest request)
        {
            var usuario = usuarios.FirstOrDefault(u =>
                u.Login == request.Login &&
                u.Senha == request.Senha);

            if (usuario == null)
            {
                return new LoginResp
                {
                    Sucesso = false,
                    Mensagem = "Usuário ou senha inválidos."
                };
            }

            var expira = DateTime.UtcNow.AddMinutes(_jwt.ExpireMinutes);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Login),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nome),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, "Administrador"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwt.Key));

            var credenciais = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: expira,
                signingCredentials: credenciais
            );

            return new LoginResp
            {
                Sucesso = true,
                Nome = usuario.Nome,
                Mensagem = "Login realizado com sucesso.",
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiraEm = expira
            };
        }
    }
}