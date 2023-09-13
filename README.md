# Todo API

The Todo API is a simple ASP.NET Core web service for managing tasks.

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)

## Features

- **Create Todos:** Add new tasks to the list.
- **Read Todos:** Retrieve a list of all tasks or a specific task by ID.
- **Update Todos:** Modify existing tasks.
- **Delete Todos:** Remove tasks from the list.

## Getting Started

1. **Prerequisites:**
   - .NET SDK ([Install](https://dotnet.microsoft.com/download))
   - Visual Studio IDE
   
2. **Clone the Repository:**
   ```bash
   git clone https://github.com/m-ata/todo-api.git
3. **Run the project:**
   - Open the project in Visual Studio
   - Right click on TodoApi, Select `Run Project`.
4. **Access the API**
  Base URL: http://localhost:5147/api

## API Endpoints
1. **GET /todos:** Retrieve a list of all todos.
2. **POST /addTodo:** Create a new todo.
3. **PUT /updateTodo/{id}:** Update an existing todo by specifying its ID.
4. **DELETE /deleteTodo/{id}:** Delete a todo based on its ID.

For more detailed information, please refer to the Swagger documentation at http://localhost:5147/swagger/index.html.
