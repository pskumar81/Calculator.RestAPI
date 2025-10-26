# Calculator REST API - Copilot Instructions

This project is a Calculator REST API built with ASP.NET Core 9.0.

## Project Overview
- **Language**: C#
- **Framework**: ASP.NET Core 9.0 Web API
- **Architecture**: Clean architecture with controllers, services, and models
- **Documentation**: Swagger/OpenAPI integration
- **Features**: Basic arithmetic operations (Add, Subtract, Multiply, Divide)

## Project Structure
- `Controllers/` - API controllers with endpoints
- `Models/` - Request/response models and enums
- `Services/` - Business logic and interfaces
- `.vscode/` - VS Code configuration (tasks, launch settings)

## Development Guidelines
- Use dependency injection for services
- Include XML documentation comments for public APIs
- Follow RESTful API conventions
- Implement proper error handling and logging
- Use async/await patterns where appropriate

## Available Tasks
- **Build**: `dotnet build` - Compile the project
- **Run**: `dotnet run` - Start the development server
- **Restore**: `dotnet restore` - Restore NuGet packages

## Launch Instructions
1. Press F5 to start debugging with automatic browser launch
2. Use "Launch Calculator API (No Browser)" for debugging without browser
3. Access Swagger UI at the root URL when running in development mode

## API Endpoints
- POST `/api/calculator/calculate` - Main calculation endpoint
- GET `/api/calculator/add` - Addition endpoint
- GET `/api/calculator/subtract` - Subtraction endpoint  
- GET `/api/calculator/multiply` - Multiplication endpoint
- GET `/api/calculator/divide` - Division endpoint
- GET `/api/calculator/health` - Health check endpoint

The project is ready for development and testing.