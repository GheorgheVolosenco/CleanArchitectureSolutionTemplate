 # Clean Architecture Solution Template

This is a solution template for creating a .NET Core API following the principles of Clean Architecture. 

## Technologies

* [ASP.NET Core 5]("https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-5.0&tabs=windows")
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/), [NSubstitute](https://nsubstitute.github.io/)

## Others

* [Swagger]("https://swagger.io/")
* [Microsoft Core Identity]("https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio")
* [PostgreSQL]("https://www.postgresql.org/")

## Getting Started

1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
1. Clone the project

### Database Configuration

The template is configured to use a PostgreSQL database.<br/>

Prerequisites:
1. Install `PostreSQL` database locally
1. Install [pgAdmin4]("https://www.pgadmin.org/download/") to manage PostreSQL databases
1. Install [dotnet ef]("https://docs.microsoft.com/en-us/ef/core/cli/dotnet") tools -> `dotnet tool install --global dotnet-ef`

Update **WebAPI/appsettings.json** as follows:

* Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid PostgreSQL Server instance. 
* When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/Infrastructure.Identity` (optional if in this folder)
* `--project src/Infrastructure.Persistence` (optional if in this folder)
* `--startup-project src/WebUI`
* `--output-dir Infrastructure.Identity/Migrations` (for Identity Context)
* `--output-dir Infrastructure.Persistence/Migrations` (for ApplicationDb Context)

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\Infrastructure.Persistence --startup-project src\WebUI --output-dir Infrastructure.Persistence\Migrations`

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebAPI

This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure. When run, it opens a Swagger API documentation page.

## Others

* CORS support: In `WebAPI/appsettings.json`, property `CorsOrigins` contains allowed origins separated by comma. 
* Security Headers middleware that adds some security headers.
* Health endpoint that can be found at `{app_url}/health` -> It tests if the application and the database are alive.

## Testing (TBD)
* Unit tests: TBD
* Integration tests: TBD

## License

This project is licensed with the [MIT license](LICENSE).