# Calculator REST API

A simple Calculator REST API built with ASP.NET Core that provides basic arithmetic operations (addition, subtraction, multiplication, and division).

## Features

- **RESTful API** for calculator operations
- **Swagger/OpenAPI documentation** for easy testing and exploration
- **Comprehensive logging** for debugging and monitoring
- **Error handling** with proper HTTP status codes
- **CORS support** for cross-origin requests
- **Dependency injection** for clean architecture
- **Multiple endpoint formats** (POST with JSON body and GET with query parameters)

## API Endpoints

### Calculator Operations

#### POST /api/calculator/calculate
Perform calculations using JSON request body.

**Request Body:**
```json
{
    "firstNumber": 10,
    "secondNumber": 5,
    "operation": "Add"
}
```

**Response:**
```json
{
    "firstNumber": 10,
    "secondNumber": 5,
    "operation": "Add",
    "result": 15,
    "timestamp": "2025-10-26T12:00:00Z",
    "isSuccess": true,
    "errorMessage": null
}
```

#### GET Endpoints
- `GET /api/calculator/add?a=10&b=5` - Add two numbers
- `GET /api/calculator/subtract?a=10&b=5` - Subtract two numbers
- `GET /api/calculator/multiply?a=10&b=5` - Multiply two numbers
- `GET /api/calculator/divide?a=10&b=5` - Divide two numbers

#### Health Check
- `GET /api/calculator/health` - Check API health status

## Supported Operations

- **Add** - Addition of two numbers
- **Subtract** - Subtraction of two numbers
- **Multiply** - Multiplication of two numbers
- **Divide** - Division of two numbers (with zero-division protection)

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) (recommended)
- [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for VS Code

### Building and Running

#### Using .NET CLI

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Calculator.RestAPI
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

#### Using VS Code

1. **Open the project** in VS Code
2. **Press F5** to start debugging, or
3. **Use Ctrl+Shift+P** and run "Tasks: Run Task" → "Run Calculator API"

### Accessing the API

Once running, the API will be available at:
- **HTTPS**: `https://localhost:7xxx` (port varies)
- **HTTP**: `http://localhost:5xxx` (port varies)

The **Swagger UI** will be available at the root URL when running in Development mode.

## Project Structure

```
Calculator.RestAPI/
├── Controllers/
│   └── CalculatorController.cs    # API endpoints
├── Models/
│   ├── CalculationRequest.cs      # Request model
│   ├── CalculationResponse.cs     # Response model
│   └── OperationType.cs           # Operation enumeration
├── Services/
│   ├── ICalculatorService.cs      # Service interface
│   └── CalculatorService.cs       # Business logic implementation
├── Properties/
│   └── launchSettings.json        # Launch configuration
├── .vscode/
│   ├── launch.json                # Debug configuration
│   └── tasks.json                 # Build/run tasks
├── Program.cs                     # Application startup
├── Calculator.RestAPI.csproj      # Project file
├── appsettings.json              # Configuration
└── README.md                     # This file
```

## Development

### Adding New Operations

1. Add new operation to `OperationType` enum
2. Implement the operation in `CalculatorService`
3. Add corresponding endpoint in `CalculatorController`

### Testing

You can test the API using:
- **Swagger UI** (available at root when running)
- **Postman** or similar REST client
- **curl** commands
- **VS Code REST Client** extension with `.http` files

### Example curl Commands

```bash
# Addition
curl -X POST "https://localhost:7xxx/api/calculator/calculate" \
     -H "Content-Type: application/json" \
     -d '{"firstNumber": 10, "secondNumber": 5, "operation": "Add"}'

# Division using GET
curl "https://localhost:7xxx/api/calculator/divide?a=10&b=2"

# Health check
curl "https://localhost:7xxx/api/calculator/health"
```

## Configuration

The application uses standard ASP.NET Core configuration:
- `appsettings.json` - Production settings
- `appsettings.Development.json` - Development settings
- Environment variables override file settings

## Logging

The application includes comprehensive logging:
- **Console logging** in development
- **Debug output** for troubleshooting
- **Structured logging** for operations and errors

## Error Handling

The API handles various error scenarios:
- **Invalid operations** - Returns 400 Bad Request
- **Division by zero** - Returns 400 Bad Request with error message
- **Null/empty requests** - Returns 400 Bad Request
- **Server errors** - Returns 500 Internal Server Error

## License

This project is available under the MIT License.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## Related Projects

This Calculator REST API is inspired by messaging-based calculator implementations:
- [Calculator.RabbitMQ](https://github.com/pskumar81/Calculator.RabbitMQ)
- [Calculator.Kafka](https://github.com/pskumar81/Calculator.Kafka)