# 🐳 Docker Containerization Guide

This guide explains how to run the Calculator REST API and web client using Docker containers.

## 📋 Prerequisites

- [Docker](https://www.docker.com/get-started) installed and running
- [Docker Compose](https://docs.docker.com/compose/install/) (usually included with Docker Desktop)

## 🚀 Quick Start

### Option 1: Using Docker Compose (Recommended)

```bash
# Build and start all services
docker-compose up --build -d

# Or use the convenience script
./docker-run.sh          # Linux/Mac
docker-run.bat           # Windows
```

### Option 2: Manual Docker Commands

```bash
# Build the API image
docker build -t calculator-api .

# Build the client image
docker build -t calculator-client ./client

# Create a network
docker network create calculator-network

# Run the API container
docker run -d --name calculator-api --network calculator-network -p 5000:8080 calculator-api

# Run the client container
docker run -d --name calculator-client --network calculator-network -p 3000:80 calculator-client
```

## 🌐 Access URLs

After starting the containers:

| Service | URL | Description |
|---------|-----|-------------|
| **Web Client** | http://localhost:3000 | Interactive web calculator |
| **API Server** | http://localhost:5000 | REST API endpoints |
| **Swagger UI** | http://localhost:5000 | API documentation |

## 📁 Container Architecture

```
┌─────────────────────────────────────┐
│            Docker Host              │
│                                     │
│  ┌─────────────────┐ ┌────────────┐ │
│  │  Web Client     │ │ API Server │ │
│  │  (nginx:alpine) │ │ (dotnet:9) │ │
│  │  Port: 3000     │ │ Port: 5000 │ │
│  └─────────────────┘ └────────────┘ │
│           │                  │      │
│           └──────────────────┘      │
│           calculator-network        │
└─────────────────────────────────────┘
```

## 🔧 Container Management

### View Container Status
```bash
docker-compose ps
```

### View Logs
```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f calculator-api
docker-compose logs -f calculator-client
```

### Stop Containers
```bash
docker-compose down
```

### Restart Containers
```bash
docker-compose restart
```

### Rebuild and Restart
```bash
docker-compose up --build -d
```

## 🐛 Troubleshooting

### Container Won't Start
```bash
# Check container logs
docker-compose logs calculator-api
docker-compose logs calculator-client

# Check if ports are available
netstat -tulpn | grep :5000
netstat -tulpn | grep :3000
```

### Port Conflicts
If ports 3000 or 5000 are already in use, modify `docker-compose.yml`:

```yaml
services:
  calculator-api:
    ports:
      - "5001:8080"  # Change 5000 to 5001
  
  calculator-client:
    ports:
      - "3001:80"    # Change 3000 to 3001
```

### API Connection Issues
If the web client can't connect to the API:

1. Ensure both containers are on the same network
2. Check if API container is healthy: `docker-compose ps`
3. Verify API is responding: `curl http://localhost:5000/api/calculator/health`

## 🔒 Production Considerations

### Security
- Use HTTPS in production
- Implement proper CORS policies
- Add authentication/authorization
- Use secrets management for sensitive data

### Performance
- Enable multi-stage builds for smaller images
- Use health checks for container orchestration
- Implement proper logging and monitoring

### Scaling
```bash
# Scale API instances
docker-compose up --scale calculator-api=3 -d
```

## 🏗️ Development Mode

For development with hot reload:

```bash
# Use development compose file
docker-compose -f docker-compose.dev.yml up --build -d
```

## 📊 Health Checks

The API container includes health checks:

```bash
# Check container health
docker inspect calculator-rest-api | grep Health -A 10
```

## 🧹 Cleanup

Remove all containers and images:

```bash
# Stop and remove containers
docker-compose down

# Remove images
docker rmi calculator-api calculator-client

# Remove unused Docker resources
docker system prune -a
```

## 📝 File Structure

```
Calculator.RestAPI/
├── Dockerfile                    # API container definition
├── .dockerignore                # Docker ignore file
├── docker-compose.yml           # Multi-container orchestration
├── docker-compose.dev.yml       # Development configuration
├── docker-run.sh               # Linux/Mac startup script
├── docker-run.bat              # Windows startup script
├── client/
│   ├── Dockerfile              # Client container definition
│   └── index.html              # Web client application
└── [API source files...]
```

## 🎯 Next Steps

1. **Test the containers**: Visit http://localhost:3000 and http://localhost:5000
2. **Customize configuration**: Modify docker-compose.yml as needed
3. **Deploy to cloud**: Use the same containers in AWS, Azure, or GCP
4. **Set up CI/CD**: Automate container builds and deployments
5. **Add monitoring**: Implement logging and health monitoring

Happy containerizing! 🚀