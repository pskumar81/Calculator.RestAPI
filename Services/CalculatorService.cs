using Calculator.RestAPI.Models;

namespace Calculator.RestAPI.Services
{
    /// <summary>
    /// Calculator service implementation
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;

        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Perform calculation based on the request
        /// </summary>
        /// <param name="request">Calculation request</param>
        /// <returns>Calculation response</returns>
        public async Task<CalculationResponse> CalculateAsync(CalculationRequest request)
        {
            _logger.LogInformation("Performing calculation: {FirstNumber} {Operation} {SecondNumber}", 
                request.FirstNumber, request.Operation, request.SecondNumber);

            var response = new CalculationResponse
            {
                FirstNumber = request.FirstNumber,
                SecondNumber = request.SecondNumber,
                Operation = request.Operation
            };

            try
            {
                if (!Enum.TryParse<OperationType>(request.Operation, true, out var operationType))
                {
                    throw new ArgumentException($"Invalid operation: {request.Operation}");
                }

                response.Result = operationType switch
                {
                    OperationType.Add => Add(request.FirstNumber, request.SecondNumber),
                    OperationType.Subtract => Subtract(request.FirstNumber, request.SecondNumber),
                    OperationType.Multiply => Multiply(request.FirstNumber, request.SecondNumber),
                    OperationType.Divide => Divide(request.FirstNumber, request.SecondNumber),
                    _ => throw new ArgumentException($"Unsupported operation: {request.Operation}")
                };

                _logger.LogInformation("Calculation completed successfully. Result: {Result}", response.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing calculation");
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of the numbers</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtract second number from first number
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Difference of the numbers</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Product of the numbers</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divide first number by second number
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Quotient of the numbers</returns>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return a / b;
        }
    }
}