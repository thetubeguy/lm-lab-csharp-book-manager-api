# 📖 Minimalist Book Manager API - C# ASP.NET Core MVC Web API

## Introduction
This is the starter repository for the Further APIs session. It provides some starter code to creating a Minimalist Book Manager API with synchronous API endpoints.

### Pre-Requisites
- C# / .NET 6
- NuGet

### Technologies & Dependencies
- ASP.NET Core MVC 6 (Web API Project)
- NUnit testing framework
- Moq

### How to Get Started
- Fork this repo to your Github and then clone the forked version of this repo.

### Main Entry Point
- The Main Entry Point for the application is: [Program.cs](./BookManagerApi/Program.cs)

### Running the Unit Tests
- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory, run:

`dotnet test`

### End Points

- GET: api/v1/book
  Returns all books in the DB
  
- GET: /api/v1/book/{id}
  Returns the book with Id if it exists.
  Otherwise returns a NotFoundResult with status 404

- DELETE: /api/v1/book/{id}
  Returns a string confirming the deletion if the book with Id exists.
  Otherwise returns a NotFoundResult with status 404

- PUT: /api/v1/book/{id}
  Changes the details of book with matching Id.  Book details are in request body.
  Returns a NoContentResult.
  
- POST: /api/v1/book
  Adds a new book to the database.   Book details are in request body.
  Returns a CreatedAtAction result (pointing to the new book) if successful.
  Other wise returns an ActionResult with Status 400 and ValidationProblemDetails stating that Id already exists
  

  
