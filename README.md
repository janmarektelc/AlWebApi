# <img src="IconTransparent.png" width="50"> WebApi Application

**Project Description:**

This application is a simple Web API application built using C#, ASP.NET Core, Entity Framework, and MSSQL. The application exposes a RESTful API and is documented using Swagger/OpenAPI.

## Prerequisites

Before you can run the application, you need to have the following software installed:

* **.NET SDK:** Ensure you have the .NET SDK (Software Development Kit) installed. Version 8.0 or later is recommended. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).
* **MSSQL Server:** You need an instance of Microsoft SQL Server running. This can be a local installation, a cloud-based instance, or a Docker container. You can also use just mock data by setting flag **UseMockData** in this configuration file.
* **Code Editor/IDE:** A code editor or Integrated Development Environment (IDE) is needed to work with the source code. Visual Studio, Visual Studio Code, or JetBrains Rider are popular choices.
* **Git (Optional):** If you intend to clone the repository from a Git hosting service, you'll need Git installed. You can download it from [git-scm.com](https://git-scm.com/downloads).

## Technologies Used

* **C# and ASP.NET Core:** Backend development.
* **Entity Framework Core:** Object-Relational Mapping (ORM) for database interactions.
* **MediatR:** Mediator pattern implementation.
* **MSSQL:** Database for data storage.
* **Swagger/OpenAPI:** API documentation and testing.
* **MSTest:** Unit testing framework.

## Application Architecture

The application follows a layered architecture, incorporating the Mediator pattern to decouple components and improve maintainability:

* **Controller Layer:** Handles HTTP requests and responses. Controllers act as entry points for the API, forwarding requests to the Mediator.
* **Mediator Layer:** Implements the Mediator pattern using a library MediatR. It acts as a central hub, routing requests to their respective handlers.
* **Request/Response Handlers:** Contain the business logic for specific requests. Handlers are responsible for processing requests and returning responses.
* **Service Layer:** Contains business logic and interacts with the data access layer.
* **Data Access Layer (Repository):** Manages database interactions using Entity Framework Core.
* **Model Layer:** Defines data entities and database models.

## Database Design

The application uses an MSSQL database to store data. The database schema includes the following tables:

* **Products:** Stores product information (Id, Name, ImageUri, Price Description).

## Swagger/OpenAPI

The application uses Swagger/OpenAPI to generate interactive API documentation. The Swagger UI allows developers to explore and test the API endpoints.

## Getting Started

1.  **Clone the repository:** `git clone https://github.com/janmarektelc/AlWebApi.git`
2.  **Navigate to the folder:** `cd .\AlWebApi`
3.  **Restore NuGet packages:** `dotnet restore`
4.  **Update the database connection string:** Modify the `.\AlWebApi.Api\appsettings.json` file to point to your MSSQL database, or use Mock data by setting flag **UseMockData** in this configuration file.

## Running the Application from the Command Line

1.  **Run the application:** `dotnet run --project AlWebApi.Api`
2.  **Access the Swagger UI:** Open a web browser and navigate to `http://localhost:5015/swagger`

## Running Unit Tests
1.  **Run the unit tests:** `dotnet test`