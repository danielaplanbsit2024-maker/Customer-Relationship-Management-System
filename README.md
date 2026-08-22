# Customer Relationship Management System

A Windows Forms application for managing customer relationships, products, sales, orders, and customer accounts.

## Development Status

**In development**

The main CRM and customer shopping workflows are implemented, but the application is still being refined. Testing, usability improvements, and production-readiness work are still required before a stable release.

## Current Features

- Admin and customer authentication
- Customer registration and profile management
- Admin dashboard with customer, sales, and history views
- Product browsing for coffee, fruit tea, brosty, praf, and other products
- Shopping cart and checkout workflows
- Cash-on-delivery and e-wallet payment flows
- Customer reviews
- Audit history for important actions
- Local database schema initialization and updates

## Technology

- C# and Windows Forms
- .NET 10 for Windows
- SQL Server LocalDB
- `Microsoft.Data.SqlClient`
- Windows Forms DataVisualization

## Requirements

- Windows
- .NET 10 SDK
- SQL Server LocalDB (`MSSQLLocalDB`)
- Visual Studio 2022 or a compatible .NET development environment

## Getting Started

1. Clone the repository.
2. Open `Customer Relationship Management.slnx` in Visual Studio.
3. Restore NuGet packages.
4. Confirm that SQL Server LocalDB is installed and running.
5. Build and run the `Customer Relationship Management` project.

The application uses the following LocalDB connection string:

```text
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;
```

The included `Database.mdf` file is used by the application and should be handled carefully when moving the project between machines.

## Development Roadmap

- Expand automated testing for authentication, checkout, and database operations
- Improve validation and error handling across forms
- Review database security and deployment configuration
- Improve responsive layout and accessibility of the Windows Forms UI
- Prepare a documented production deployment process

## Notes

This project is intended for ongoing development and learning. Do not use the default administrator credentials in a production environment, and review the database configuration before distributing the application.