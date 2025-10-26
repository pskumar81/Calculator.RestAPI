namespace Calculator.RestAPI.Models
{
    /// <summary>
    /// Request model for calculator operations
    /// </summary>
    public class CalculationRequest
    {
        /// <summary>
        /// First operand
        /// </summary>
        public double FirstNumber { get; set; }

        /// <summary>
        /// Second operand
        /// </summary>
        public double SecondNumber { get; set; }

        /// <summary>
        /// Operation type (Add, Subtract, Multiply, Divide)
        /// </summary>
        public string Operation { get; set; } = string.Empty;
    }
}