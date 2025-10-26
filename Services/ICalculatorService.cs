using Calculator.RestAPI.Models;

namespace Calculator.RestAPI.Services
{
    /// <summary>
    /// Interface for calculator service operations
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Perform calculation based on the request
        /// </summary>
        /// <param name="request">Calculation request</param>
        /// <returns>Calculation response</returns>
        Task<CalculationResponse> CalculateAsync(CalculationRequest request);

        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of the numbers</returns>
        double Add(double a, double b);

        /// <summary>
        /// Subtract second number from first number
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Difference of the numbers</returns>
        double Subtract(double a, double b);

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Product of the numbers</returns>
        double Multiply(double a, double b);

        /// <summary>
        /// Divide first number by second number
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Quotient of the numbers</returns>
        double Divide(double a, double b);
    }
}