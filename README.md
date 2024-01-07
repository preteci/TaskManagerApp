## About the API

Task Manager API made with .NET 8.0 and MS SQL Server for Database, using Layered Arhitecture.

In order to use this API you need to have following installed:
- .net 8.0
- MS SQL Server

## Configuration

Please change DefaultConnection string in **appsettings.json** to your database string on your local machine.

## Lunching project

Clone repository and position yourself with your CLI inside TaskManagerApp/TaskManagerV1 folder and run the following commands:
```
dotnet build
dotnet run
```

Note: This application can be run throught Visual Studio as well.

This api supports Swagger UI that can be acces via next URL:

```
/swagger/index.html
```
