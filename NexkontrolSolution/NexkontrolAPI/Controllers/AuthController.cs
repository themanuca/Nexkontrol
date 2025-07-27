using Application.Interfaces;
using Contract.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NexkontrolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                _logger.LogInformation("Usuário tentou registrar.");
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo de registro inválido.");
                    return BadRequest(ModelState);
                }
                    
                var result = await _authService.RegisterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao registrar usuário: {Message}", ex.Message); // << LOG DA EXCEÇÃO É CRÍTICO
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                _logger.LogInformation("Usuário tentou logar.");
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo de login inválido.");
                    return BadRequest(ModelState);
                }
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao logar usuário: {Message}", ex.Message); // << LOG DA EXCEÇÃO É CRÍTICO

                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
