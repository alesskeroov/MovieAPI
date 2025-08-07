# MovieAPI Backend

This project is a simple movie catalog backend built with ASP.NET Core Web API. It features **JWT Authentication** and **role-based authorization** with Admin and User roles.

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- JWT Authentication
- Role-based Authorization (Admin and User roles)

## Features

- **Admin**:
  - Create new movies
  - Update existing movies
  - Delete movies
- **User**:
  - View movies (read-only)

## API Endpoints (example)

| HTTP Method | URL               | Description                   | Role        |
|-------------|-------------------|-------------------------------|-------------|
| GET         | /api/movies       | Get all movies                | User/Admin  |
| GET         | /api/movies/{id}  | Get movie details by ID       | User/Admin  |
| POST        | /api/movies       | Add a new movie               | Admin       |
| PUT         | /api/movies/{id}  | Update movie information      | Admin       |
| DELETE      | /api/movies/{id}  | Delete a movie                | Admin       |
| POST        | /api/auth/login   | User login and token request  | Everyone    |

## Setup and Usage

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/MovieAPI.git
    ```

2. Navigate into the project folder:
    ```bash
    cd MovieAPI
    ```

3. Configure the database connection string in `appsettings.json`.

4. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

5. Run the server:
    ```bash
    dotnet run
    ```

6. Access the API using Postman or any HTTP client.

## Notes

- The `.vs/` and other build folders are excluded via `.gitignore`.
- To obtain a JWT token, use the `/api/auth/login` endpoint.

---

If you have any questions, feel free to reach out.

---

**© 2025, Rəvan Ələsgərov**
