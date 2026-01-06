# Integrated Productivity System

This project is an integrated productivity management solution designed for operational teams, contracts, work orders, payments, and performance indicators. Built with .NET 8 and Entity Framework Core, it supports PostgreSQL and SQLite databases and follows a layered architecture (Domain, Infra, Application, API).

## Main Features

- Management of field teams, contracts, projects, and activities
- Work order tracking and costumer information
- Payment and finishing details management
- Import data from Excel spreadsheets
- RESTful API endpoints for all entities
- Authentication and validation mechanisms
- Database integration with PostgreSQL (production) and SQLite (development/testing)
- Modular and extensible codebase

## Technologies

- .NET 8
- Entity Framework Core
- PostgreSQL / SQLite
- AutoMapper
- ASP.NET Core Web API

## Getting Started

1. Clone the repository.
2. Configure the database connection in `appsettings.json` or environment files.
3. Run database migrations and seed data if necessary.
4. Start the API project (`src/Indica.Productivity.API`).

## Folder Structure

- `src/Indica.Productivity.Domain`: Domain entities and interfaces
- `src/Indica.Productivity.Infra`: Database context, entity mappers, repositories
- `src/Indica.Productivity.Application`: DTOs, services, validation, mapping
- `src/Indica.Productivity.API`: REST API controllers and startup configuration

## License

This project is proprietary and intended for internal use.
