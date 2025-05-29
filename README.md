# Library Management System

This project is a proof-of-concept web application for managing a library's books and clients. Built with .NET 8.0, it follows clean architecture principles and provides comprehensive functionality for managing book loans and client memberships. The application includes full support for tracking books, managing client information, and handling book loans.

## Technology Stack

- ASP.NET Core Web API (.NET 8.0)
- Entity Framework Core
- SQL Server
- AutoMapper
- xUnit for testing
- Clean (Layered) Architecture

## Project Structure

- **WebApi** - Contains API controllers and the application entry point
- **Service** - Business logic, DTOs, and mapping profiles
- **Data** - Entity Framework Core context, repositories, and entity models
- **Tests** - Unit tests for services

## Features

### 1. Book Management

- Create, read, update, and delete books
- Validation:
  - IBAN is required (unique book identifier)
  - Name is required (max 200 characters)
  - Author is required (max 200 characters)
  - Publisher is required (max 200 characters)
  - Year is required
  - NumberOfCopies is required
- Example format:

```json
{
  "iban": "978-1-4088-5589-8",
  "name": "The Alchemist",
  "author": "Paulo Coelho",
  "publisher": "HarperOne",
  "year": 1988,
  "numberOfCopies": 6
}
```

### 2. Client Management

- Create, read, update, and delete clients
- Validation:
  - FirstName is required (max 100 characters)
  - LastName is required (max 200 characters)
  - DateOfBirth is required
  - Address is required (max 400 characters)
  - MembershipCardNumber is required
  - MembershipCardValidityDate is required
  - BookId must reference an existing book
- Example format:

```json
{
  "firstName": "Jovan",
  "lastName": "Tone",
  "dateOfBirth": "2004-04-28",
  "address": "123 Main St",
  "membershipCardNumber": "MC123456",
  "membershipCardValidityDate": "2024-12-31",
  "loanDate": "2024-05-25",
  "returnDate": "2024-06-25",
  "bookId": 1
}
```

## API Endpoints

### Books

- GET /api/Book - Get all books
- GET /api/Book/{id} - Get a book by ID
- POST /api/Book - Create a new book
- PUT /api/Book/{id} - Update a book
- DELETE /api/Book/{id} - Delete a book

### Clients

- GET /api/Client - Get all clients
- GET /api/Client/{id} - Get a client by ID
- POST /api/Client - Create a new client
- PUT /api/Client/{id} - Update a client
- DELETE /api/Client/{id} - Delete a client

## Database Setup

1. Ensure SQL Server is running
2. Run the queries inside FinalExamDB.sql
3. Update the connection string in appsettings.json

## Running Tests

To run all tests:

```bash
dotnet test
```

The test suite includes:
- BookService tests (GetAll, GetById, Create)
- ClientService tests (GetAll, GetById, Create)

## Key Features

- One-to-many relationship between Books and Clients
- Automatic ID generation for both Books and Clients
- Proper validation on all fields
- Swagger UI documentation with examples
- Clean architecture with repository pattern
- Comprehensive unit tests
- CORS enabled for cross-origin requests

## Author

Jovan Tone 5618