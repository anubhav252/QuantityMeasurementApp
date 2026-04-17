using HistoryService.DTOs;
using HistoryService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HistoryService.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        private string? GetUserId()
        {
            if (!User.Identity?.IsAuthenticated ?? true) return null;
            return User.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.NameIdentifier ||
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            )?.Value;
        }

        /// <summary>
        /// Internal endpoint called by QMAOperationService to persist an operation.
        /// Not exposed through the public gateway.
        /// </summary>
        [HttpPost("save")]
        public IActionResult Save([FromBody] SaveOperationRequest request)
        {
            _historyService.SaveOperation(request);
            return Ok(new { message = "Operation saved" });
        }

        /// <summary>
        /// Returns all operations and quantities for the authenticated user.
        /// Exposed publicly via the gateway at GET /api/history.
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult GetHistory()
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized(new { message = "User not found in token" });

            var result = _historyService.GetHistoryByUser(userId);
            return Ok(result);
        }

        /// <summary>
        /// Deletes all history records for the authenticated user.
        /// Exposed publicly via the gateway at DELETE /api/history.
        /// </summary>
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteHistory()
        {
            var userId = GetUserId();
            if (userId == null)
                return Unauthorized(new { message = "User not found in token" });

            _historyService.DeleteHistoryByUser(userId);
            return Ok(new { message = "History deleted" });
        }
    }
}
