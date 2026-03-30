using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using QuantityMeasurementAPI.DTOs;
using QuantityMeasurementModel.DTOs;
using QuantityMeasurementModel.Models;
using QuantityMeasurementServices.Interfaces;

namespace QuantityMeasurementAPI.Controllers
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

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] CompareRequest request)
        {
            var result = _service.Compare(request.First, request.Second);
            return Ok(new 
            {
                result,
                first=request.First,
                second=request.Second,
                message=result?"quantites are equal ":"quantities are not equal"
            });
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityRequest request)
        {
            var result = _service.Add(request.First, request.Second, request.TargetUnit);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityRequest request)
        {
            var result = _service.Subtract(request.First, request.Second, request.TargetUnit);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] DivideRequest request)
        {
            var result = _service.Divide(request.First, request.Second);
            return Ok(new 
            {
                BaseValue=result,
                Unit="ratio",
                Category=request.First.Category
            });
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequest request)
        {
            var result = _service.Convert(request.Input, request.TargetUnit);
            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult History()
        {
            var result = _service.GetFullHistory();
            return Ok(result);
        }

        [HttpDelete("clear")]
        public IActionResult DeleteAll()
        {
            _service.DeleteAllRecords();
            return Ok("Deleted");
        }
    }
}