# English QA App

A full-stack English Question & Answer application built with **C#, ASP.NET Core, Entity Framework Core, SQLite, and React**.

The project includes a RESTful backend API and a React frontend that work together to provide an application for managing 
and working with English questions and answers.

## Technologies

### Backend

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* JWT Authentication
* Swagger / OpenAPI
* LINQ

### Frontend

* React
* JavaScript
* HTML
* CSS
* Axios

## Features

* User authentication and authorization
* Question and answer management
* CRUD operations
* Database integration with Entity Framework Core
* JWT-based authentication
* Filtering and pagination
* RESTful API
* Communication between the React frontend and ASP.NET Core backend

## Architecture

The backend is organized into separate layers:

* **Controllers** – Handle HTTP requests and API endpoints
* **Services** – Handle application and business logic
* **Repositories** – Handle database operations
* **DTOs** – Define the data transferred through the API
* **Models** – Represent application entities
* **Data** – Contains database and Entity Framework Core configuration

The frontend is built separately using React and communicates with the backend through the API.

## How It Works

The application follows a client-server architecture.

The **React frontend** communicates with the **ASP.NET Core Web API** through HTTP requests. The backend handles the application logic, authentication, and database operations using **Entity Framework Core** and **SQLite**.


## Authentication

The backend uses **JWT-based authentication and authorization** to control access to protected API functionality.

## Database

The application uses **SQLite** with **Entity Framework Core** for data persistence.

## Purpose

This project was built for learning and practical experience with **full-stack web development**.

It provided practical experience with building a backend API using **C# and ASP.NET Core**, working with databases through **Entity Framework Core**, implementing authentication and authorization, and connecting a **React frontend** to a REST API.


