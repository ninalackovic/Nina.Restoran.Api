# Nina.Restoran.Api

A RESTful API for managing restaurant tables, people, and reservations. Built with ASP.NET Core (.NET 9), Entity Framework Core, and SQL Server.

## Features

- **Tables**: Create, update, delete, and list restaurant tables.
- **People**: Manage people (guests/customers) with CRUD operations.
- **Reservations**: Create, update, delete, and list reservations, linking people and tables.

## Technologies

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core (with SQL Server)
- OpenAPI (Swagger) for API documentation

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Setup

1. **Clone the repository:**
   
2. **Configure the database connection:**

   The connection string is set in `Program.cs`:
   Update the server and authentication details as needed.

3. **Apply database migrations:**
 
4. **Run the API:** 

5. **Access the API documentation:**
   - When running in development, OpenAPI/Swagger UI is available at `/openapi` or `/swagger`.

## API Endpoints

### Tables

- `GET /api/tables/all` — List all tables
- `POST /api/tables/create` — Create a new table
- `PUT /api/tables/update/{id}` — Update a table
- `DELETE /api/tables/delete/{id}` — Delete a table

### People

- `GET /api/people/all` — List all people
- `POST /api/people/create` — Create a new person
- `PUT /api/people/update/{id}` — Update a person
- `DELETE /api/people/delete/{id}` — Delete a person

### Reservations

- `GET /api/reservations/all` — List all reservations
- `POST /api/reservations/create` — Create a new reservation
- `PUT /api/reservations/update/{id}` — Update a reservation
- `DELETE /api/reservations/delete/{id}` — Delete a reservation

## Project Structure

- `Controllers/` — API controllers for tables, people, and reservations
- `Domain/` — Domain models and factories
- `Infrastructure/` — Repository interfaces and database implementations
- `Program.cs` — Application entry point and service configuration

## Development

- Uses dependency injection for repositories and database context.
- Follows RESTful conventions for resource management.
- OpenAPI/Swagger is enabled for easy API exploration and testing.

## License

This project is licensed under the MIT License.

