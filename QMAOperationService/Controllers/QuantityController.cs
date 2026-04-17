using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QMAOperationService.DTOs;
using QMAOperationService.Interfaces;
using System.Security.Claims;

namespace QMAOperationService.Controllers
{
    [ApiController]
    [Route("api/quantities")]
    public class QuantityController : ControllerBase
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        private string? GetUserId()
        {
            if (!User.Identity?.IsAuthenticated ?? true) return null;
            return User.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.NameIdentifier ||
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            )?.Value;
        }

        /// <summary>Compares two quantities for equality (after base-unit conversion).</summary>
        [AllowAnonymous]
        [HttpPost("compare")]
        public async Task<IActionResult> Compare([FromBody] CompareRequest request)
        {
            var result = await _service.Compare(request.First, request.Second, GetUserId());
            return Ok(new
            {
                result,
                first   = request.First,
                second  = request.Second,
                message = result ? "quantities are equal" : "quantities are not equal"
            });
        }

        /// <summary>Adds two quantities and returns the result in the target unit.</summary>
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] QuantityRequest request)
        {
            var result = await _service.Add(request.First, request.Second, request.TargetUnit, GetUserId());
            return Ok(result);
        }

        /// <summary>Subtracts the second quantity from the first and returns the result in the target unit.</summary>
        [AllowAnonymous]
        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] QuantityRequest request)
        {
            var result = await _service.Subtract(request.First, request.Second, request.TargetUnit, GetUserId());
            return Ok(result);
        }

        /// <summary>Divides the first quantity by the second and returns the ratio.</summary>
        [AllowAnonymous]
        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] DivideRequest request)
        {
            var result = await _service.Divide(request.First, request.Second, GetUserId());
            return Ok(new
            {
                BaseValue = result,
                Unit      = "ratio",
                Category  = request.First.Category
            });
        }

        /// <summary>Converts a quantity from its current unit to the specified target unit.</summary>
        [AllowAnonymous]
        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequest request)
        {
            var result = _service.Convert(request.Input, request.TargetUnit);
            return Ok(result);
        }
    }
}
