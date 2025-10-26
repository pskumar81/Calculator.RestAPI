using Microsoft.AspNetCore.Mvc;
using Calculator.RestAPI.Models;
using Calculator.RestAPI.Services;

namespace Calculator.RestAPI.Controllers
{
    /// <summary>
    /// Calculator API controller for performing arithmetic operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        /// <summary>
        /// Perform a calculation
        /// </summary>
        /// <param name="request">Calculation request containing operands and operation</param>
        /// <returns>Calculation result</returns>
        /// <response code="200">Calculation performed successfully</response>
        /// <response code="400">Invalid request or operation</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CalculationResponse>> Calculate([FromBody] CalculationRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("Null calculation request received");
                return BadRequest("Request cannot be null");
            }

            if (string.IsNullOrWhiteSpace(request.Operation))
            {
                _logger.LogWarning("Empty operation received");
                return BadRequest("Operation cannot be null or empty");
            }

            try
            {
                var result = await _calculatorService.CalculateAsync(request);
                
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during calculation");
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of the numbers</returns>
        [HttpGet("add")]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        public async Task<ActionResult<CalculationResponse>> Add(double a, double b)
        {
            var request = new CalculationRequest
            {
                FirstNumber = a,
                SecondNumber = b,
                Operation = "Add"
            };

            return await Calculate(request);
        }

        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Difference of the numbers</returns>
        [HttpGet("subtract")]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        public async Task<ActionResult<CalculationResponse>> Subtract(double a, double b)
        {
            var request = new CalculationRequest
            {
                FirstNumber = a,
                SecondNumber = b,
                Operation = "Subtract"
            };

            return await Calculate(request);
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Product of the numbers</returns>
        [HttpGet("multiply")]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        public async Task<ActionResult<CalculationResponse>> Multiply(double a, double b)
        {
            var request = new CalculationRequest
            {
                FirstNumber = a,
                SecondNumber = b,
                Operation = "Multiply"
            };

            return await Calculate(request);
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Quotient of the numbers</returns>
        [HttpGet("divide")]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CalculationResponse>> Divide(double a, double b)
        {
            var request = new CalculationRequest
            {
                FirstNumber = a,
                SecondNumber = b,
                Operation = "Divide"
            };

            return await Calculate(request);
        }

        /// <summary>
        /// Get API health status
        /// </summary>
        /// <returns>Health status</returns>
        [HttpGet("health")]
        [ProducesResponseType(200)]
        public IActionResult Health()
        {
            return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
        }
    }
}