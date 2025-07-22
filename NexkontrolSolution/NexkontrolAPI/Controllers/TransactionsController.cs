using Application.Interfaces;
using Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NexkontrolAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
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
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var result = await _service.GetAllAsync(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userId = GetUserId();
            var result = await _service.GetByIdAsync(userId, id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TransactionCreateDto dto)
        {
            var userId = GetUserId();
            var id = await _service.CreateAsync(userId, dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TransactionUpdateDto dto)
        {
            var userId = GetUserId();
            if (id != dto.Id) { 
                return BadRequest("Id inconsistente");
            }
            await _service.UpdateAsync(userId, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetUserId();
            await _service.DeleteAsync(userId, id);
            return NoContent();
        }
    }
}
