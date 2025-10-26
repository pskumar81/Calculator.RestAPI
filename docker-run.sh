#!/bin/bash

# Build and run Calculator REST API with Docker Compose

echo "🚀 Starting Calculator REST API Containers..."
echo "📦 Building Docker images..."

# Build and start all services
docker-compose up --build -d

echo "✅ Containers started successfully!"
echo ""
echo "🌐 Access URLs:"
echo "   📊 API Server:    http://localhost:5000"
echo "   🖥️  Web Client:    http://localhost:3000"
echo "   📖 Swagger UI:    http://localhost:5000"
echo ""
echo "🔧 Useful Commands:"
echo "   📋 View logs:      docker-compose logs -f"
echo "   ⏹️  Stop:          docker-compose down"
echo "   🔄 Restart:       docker-compose restart"
echo "   📊 Status:        docker-compose ps"
echo ""
echo "🎯 Ready for testing!"