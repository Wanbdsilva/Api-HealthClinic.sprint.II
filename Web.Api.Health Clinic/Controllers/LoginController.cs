using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;
using Web.Api.Health_Clinic.Repositories;
using Web.Api.Health_Clinic.ViewsModels;

namespace Web.Api.Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository? _usuarioRepository;

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario login = _usuarioRepository!.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (login == null)
                {
                    return StatusCode(401, "Email ou senha invalidos");
                }

                //Logica token

                var claims = new[]
               {
                new Claim(JwtRegisteredClaimNames.Email, login.Email!),
                new Claim(JwtRegisteredClaimNames.Name, login.Nome!),
                new Claim(JwtRegisteredClaimNames.Jti, login.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role,login.TipoUsuario!.Titulo!)};
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinic-api-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "HealthClinic_CodeFirst_",
                    audience: "HealthClinic_CodeFirst_",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
