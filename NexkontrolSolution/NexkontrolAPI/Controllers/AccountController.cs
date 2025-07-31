using Application.Interfaces;
using Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NexkontrolAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }
        private Guid GetUserId()
        {
            var sub = User.FindFirstValue("codeVerify")
                      ?? throw new UnauthorizedAccessException("Token JWT inválido ou não contém o claim 'sub'.");

            return Guid.Parse(sub);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllbyId(Guid id)
        {
            var userId = GetUserId();
            var result = await _service.GetAllbyId(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateDto accountCreateDto )
        {
            var accountdto = new AccountDto 
            { 
                Name = accountCreateDto.Name,            
                InitialBalance = accountCreateDto.InitialBalance,
                Type = accountCreateDto.Type,
            
            };
            var userId = GetUserId();
            accountdto.UserId = userId;
            var id = await _service.CreateAccount(accountdto);
            return Ok(id);
        }
    }
}
