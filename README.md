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

## External Architecture Diagram
The system is designed with Microservice Architecture, which is followed by both synchronous and asynchronous communication types between services. In picture 1, synchronous communication is highlighted with green, and asynchronous communication is marked with orange color.

![External Architecture](/EShop/docs/images/external-architecture-diagram-dark.png#gh-dark-mode-only)
![External Architecture](/EShop/docs/images/external-architecture-diagram-light.png#gh-light-mode-only)
<p align="center">Picture 1 - External architecture diagram</p>

## Internal Architecture Diagrams
### Catalog.API
Catalog API uses a Vertical Slice Architecture together with a CQRS design pattern. Each slice has its endpoint and request handler. Slices are separated into different folders.
<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="/EShop/docs/images/internal-architecture-catalog-api-dark.png#gh-dark-mode-only">
    <img src="/EShop/docs/images/internal-architecture-catalog-api-light.png#gh-light-mode-only">
  </picture>
</p>
<p align="center">Picture 2 - Catalog.API architecture diagram</p>

### Basket.API
Basket API uses a Vertical Slice Architecture together with a CQRS and Repository design pattern. A repository pattern is implemented to add a distributed cache using the Cache-aside pattern. Each slice has its endpoint and request handler. Slices are separated into different folders.
<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="/EShop/docs/images/internal-architecture-basket-api-dark.png#gh-dark-mode-only">
    <img src="/EShop/docs/images/internal-architecture-basket-api-light.png#gh-light-mode-only">
  </picture>
</p>
<p align="center">Picture 3 - Basket.API architecture diagram</p>

### Discount.Grpc
Discount GRPC uses an N-layer Architecture.
<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="/EShop/docs/images/internal-architecture-discount-grpc-dark.png#gh-dark-mode-only">
    <img src="/EShop/docs/images/internal-architecture-discount-grpc-light.png#gh-light-mode-only">
  </picture>
</p>
<p align="center">Picture 4 - Discount.Grpc architecture diagram</p>

### Ordering.API
Ordering API uses a Clean Architecture together with CQRS, and a Domain-driven Design.
<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="/EShop/docs/images/internal-architecture-ordering-api-dark.png#gh-dark-mode-only">
    <img src="/EShop/docs/images/internal-architecture-ordering-api-light.png#gh-light-mode-only">
  </picture>
</p>
<p align="center">Picture 5 - Ordering,API architecture diagram</p>
