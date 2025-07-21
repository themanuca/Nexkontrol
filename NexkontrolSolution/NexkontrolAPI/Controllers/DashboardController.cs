using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NexkontrolAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dash/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue("codeVerify")!); // ou "userId", se você usou esse nome
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = GetUserId();
            var result = await _service.GetSummaryAsync(userId);
            return Ok(result);
        }
    }
}
