# Eshop On Microservices 
![Static Badge](https://img.shields.io/badge/Learning_Project-21a600)
![Static Badge](https://img.shields.io/badge/Udemy-A435F0?style=flat&logo=udemy&logoColor=white)

This project is part of a course called ".NET 8 Microservices: DDD, CQRS, Vertical/Clean Architecture" created by Mehmet Ozkaya. It represents a practical implementation of microservices architecture using .NET 8, domain-driven design, command and query responsibility segregation pattern (CQRS), vertical slices, and clean architecture.

## Building Blocks
The project consists of main services and shared libraries.

### Main Services
- Catalog.API - Product management service
- Basket.API - Shopping cart management service
- Discount.Grpc - Discount management service
- Ordering.API - Ordering management service
- YarpApiGateway - Reverse proxy API gateway
- Shopping.WebApp - Web application for end users

### Shared Projects
- BuildingBlocks - Holds useful abstractions for CQRS implementation, cross-cutting concerns
- BuildingBlocks.Messaging - Holds abstractions for message broker and event-driven communication between services

### Backing services
- CatalogDb - PostgreSQL database
- BasketDb - PostgreSQL database
- DiscountDb - SQLite database
- OrderingDb - SQL Server database
- DistributedCache - Redis
- MessageBroker - RabbitMQ broker

### Container Management And Orchestration
- Docker
- Docker Compose

## External Architecture
![External Architecture](/EShop/docs/images/external-architecture-diagram-dark.png#gh-dark-mode-only)
![External Architecture](/EShop/docs/images/external-architecture-diagram-light.png#gh-light-mode-only)
