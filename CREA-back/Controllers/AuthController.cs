using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CREA_back.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest(new { Message = "El correo electr�nico y la contrase�a son obligatorios." });
            }

            if (!new EmailAddressAttribute().IsValid(email))
            {
                return BadRequest(new { Message = "Formato de correo electr�nico inv�lido." });
            }

            if (_authService.ValidateUser(email, password))
            {
                return Ok(new { Message = "Inicio de sesi�n exitoso", Role = "Admin" });
            }

            return Unauthorized(new { Message = "Correo electr�nico o contrase�a inv�lidos" });
        }
    }
}

