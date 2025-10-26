namespace Calculator.RestAPI.Models
{
    /// <summary>
    /// Response model for calculator operations
    /// </summary>
    public class CalculationResponse
    {
        /// <summary>
        /// First operand used in calculation
        /// </summary>
        public double FirstNumber { get; set; }

        /// <summary>
        /// Second operand used in calculation
        /// </summary>
        public double SecondNumber { get; set; }

        /// <summary>
        /// Operation performed
        /// </summary>
        public string Operation { get; set; } = string.Empty;

        /// <summary>
        /// Result of the calculation
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        /// Timestamp of when calculation was performed
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indicates if the calculation was successful
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Error message if calculation failed
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}