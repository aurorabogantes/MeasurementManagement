# MeasurementManagement.API

A .NET Core Web API for managing measurements with CRUD operations.

## Features

- Create, Read, Update and Delete measurements
- Get all measurements or retrieve by ID
- Data validation for measurements
- SQL Server database storage
- CORS support for cross-origin requests

## Technical Stack

- .NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI documentation

## Setup

1. Configure the database connection string in `appsettings.json`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=AURORA\\SQL2022;Database=MeasuresDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

2. Run the application:
   - The API will be available at:
     - HTTP: http://localhost:5194
     - HTTPS: https://localhost:7110
   - Swagger documentation is available in development mode

## API Endpoints

### GET /measures
Retrieves all measures

### GET /measures/{id}
Retrieves a specific measure by ID

### POST /measures
Creates a new measure

### PUT /measures/{id}
Updates an existing measure

### DELETE /measures/{id}
Deletes a measure

## Data Model

A Measure consists of:
- Id (int)
- Name (string)
- Value (int)
- Date (DateTime)