# Calculator REST API Demo

## 🚀 Server Status
The Calculator REST API server is running on: **http://localhost:5127**

## 📱 Demo Instructions

### 1. **Swagger UI (Recommended)**
- The Swagger UI is already open in the Simple Browser
- You can test all endpoints directly from the Swagger interface
- Navigate to: http://localhost:5127

### 2. **Command Line Testing**

#### Health Check
```powershell
Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/health" -Method GET
```

#### Addition (GET)
```powershell
Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/add?a=15&b=25" -Method GET
```

#### Subtraction (GET)
```powershell
Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/subtract?a=50&b=20" -Method GET
```

#### Multiplication (GET)
```powershell
Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/multiply?a=8&b=7" -Method GET
```

#### Division (GET)
```powershell
Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/divide?a=100&b=4" -Method GET
```

#### POST Request with JSON
```powershell
$body = @{
    firstNumber = 123.45
    secondNumber = 67.89
    operation = "Add"
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5127/api/calculator/calculate" -Method POST -Body $body -ContentType "application/json"
```

### 3. **Using curl (if available)**
```bash
# Health check
curl http://localhost:5127/api/calculator/health

# Addition
curl "http://localhost:5127/api/calculator/add?a=15&b=25"

# POST request
curl -X POST http://localhost:5127/api/calculator/calculate \
     -H "Content-Type: application/json" \
     -d '{"firstNumber": 10, "secondNumber": 5, "operation": "Add"}'
```

### 4. **VS Code REST Client**
Use the `demo-requests.http` file with the REST Client extension to test all endpoints.

## 🧪 Test Scenarios

### ✅ Successful Operations
- **Addition**: 15 + 25 = 40
- **Subtraction**: 50 - 20 = 30
- **Multiplication**: 8 × 7 = 56
- **Division**: 100 ÷ 4 = 25

### ❌ Error Scenarios
- **Division by Zero**: Returns 400 Bad Request
- **Invalid Operation**: Returns 400 Bad Request
- **Empty Request**: Returns 400 Bad Request

## 📊 Expected Response Format
```json
{
    "firstNumber": 15,
    "secondNumber": 25,
    "operation": "Add",
    "result": 40,
    "timestamp": "2025-10-26T12:00:00Z",
    "isSuccess": true,
    "errorMessage": null
}
```

## 🌐 API Endpoints Available
- `GET /api/calculator/health` - Health check
- `GET /api/calculator/add?a={num1}&b={num2}` - Addition
- `GET /api/calculator/subtract?a={num1}&b={num2}` - Subtraction
- `GET /api/calculator/multiply?a={num1}&b={num2}` - Multiplication
- `GET /api/calculator/divide?a={num1}&b={num2}` - Division
- `POST /api/calculator/calculate` - All operations via JSON

## 🎯 Demo Complete!
The Calculator REST API is fully functional and ready for testing!