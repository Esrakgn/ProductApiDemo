# ProductApiDemo

A simple ASP.NET Core Web API built to practice core backend development concepts such as layered architecture, dependency injection, middleware, RESTful routing, and Entity Framework Core.

## Tech Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger

## Project Structure

- `ProductApiDemo.Entities` – domain models
- `ProductApiDemo.Repositories` – data access layer
- `ProductApiDemo.Services` – business logic layer
- `ProductApiDemo.WebAPI` – API layer and middleware

## Implemented Features

- CRUD operations for `Product`
- Layered architecture
- Dependency Injection
- EF Core with SQL Server
- Configuration via `appsettings.json`
- Custom middleware for request logging
- Swagger integration for API testing

## Endpoints

- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

## Database Setup

Run the following commands in Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
