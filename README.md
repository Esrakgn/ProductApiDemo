# ProductApiDemo

This project was created to strengthen my understanding of fundamental .NET backend development concepts by building a layered Web API with database integration, middleware, filtering, and pagination.


## Tech Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger

## Project Structure

- `ProductApiDemo.Entities` – domain models and request parameters
- `ProductApiDemo.Repositories` – data access layer
- `ProductApiDemo.Services` – business logic layer
- `ProductApiDemo.WebAPI` – API layer and middleware

## Implemented Features

- CRUD operations for `Product`
- Layered architecture
- Dependency Injection
- EF Core with SQL Server
- Configuration via `appsettings.json`
- Swagger integration for API testing
- Custom request logging middleware
- Global exception handling middleware
- LINQ-based filtering
- Pagination support

## Endpoints

- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

## Query Support

The `GET /api/products` endpoint supports:

- filtering by `Name`
- filtering by `MinPrice`
- filtering by `MaxPrice`
- pagination with `PageNumber`
- pagination with `PageSize`

Example:

```text
/api/products?Name=Pen&MinPrice=50&PageNumber=1&PageSize=5


Database Setup

Run the following commands in Package Manager Console:
Add-Migration InitialCreate
Update-Database


