# Todo API

The Todo API is a simple ASP.NET Core web service for managing tasks.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Usage Examples](#usage-examples)

## Introduction

This Todo API provides endpoints to perform basic operations like creating, reading, updating, and deleting tasks (todos). It uses an in-memory database to store todo data.

## Features

- **Create Todos:** Add new tasks to the list.
- **Read Todos:** Retrieve a list of all tasks or a specific task by ID.
- **Update Todos:** Modify existing tasks.
- **Delete Todos:** Remove tasks from the list.

## Getting Started

1. **Prerequisites:**
   - .NET SDK ([Install](https://dotnet.microsoft.com/download))
   - Visual Studio Code or Visual Studio IDE (optional but recommended)
   
2. **Clone the Repository:**
   ```bash
   git clone https://github.com/m-ata/todo-api.git
3. **Access the API:**
  Base URL: http://localhost:5147/api

## API Endpoints
1. **GET /todos:** Retrieve a list of all todos.
2. **POST /addTodo:** Create a new todo.
3. **PUT /updateTodo/{id}:** Update an existing todo by specifying its ID.
4. **DELETE /deleteTodo/{id}:** Delete a todo based on its ID.

## Usage Examples

1. **Retrieve All Todos**
  URL: /todos
  Response: Array of `TodoModel`
2. **Create a Todo**
  URL: /addTodo

***Payload:***
```json 
    {
    "task": "Muhammad Orientation",
    "deadline": "2023-09-12T23:59:59.999Z",
    "isCompleted": false
    }
```
***Response:***
```json
    {
    "id": 1, // auto generated
    "task": "Muhammad - Training - RTK",
    "deadline": "2023-09-12T23:59:59.999Z",
    "isCompleted": false
    }
```
4. **Update a Todo**
URL: /updateTodo/{id}

***Payload:***
```json
    {
      "id": 1,
      "task": "Muhammad Training",
      "deadline": "2023-09-12T23:59:59.999Z",
      "isCompleted": false
    }
```
***Response:***
 ```json
  {
     "id": 1,
     "task": "Muhammad - Training - RTK",
     "deadline": "2023-09-12T23:59:59.999Z",
     "isCompleted": false
  }
```
5. **Delete a Todo**
URL: /deleteTodo/{id}
***Response:***
```json
  {
    "id": // id passed in parameter
    "success": true
  }
```
PS: For more detailed information, please refer to the Swagger documentation at http://localhost:5147/swagger/index.html.
