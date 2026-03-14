# Byway API

Byway API is a robust backend service built with **ASP.NET Core**, designed to power the Byway learning platform. It manages the core logic for user authentication, course management, instructor workflows, and secure payment processing.

---

## Features

* **Authentication & Authorization:** Secure user access using ASP.NET Core Identity and JWT tokens.
* **Course Management:** Full CRUD operations for courses, categories, and lessons.
* **Instructor Portal:** Specialized endpoints for instructors to manage their curriculum and track student engagement.
* **Payment Workflow:** Integrated logic for handling course enrollments and payment processing.
* **Scalable Architecture:** Built following clean architecture principles to ensure maintainability and testability.

## 🛠️ Tech Stack

* **Framework:** .NET 8.0 / ASP.NET Core Web API
* **Database:** Entity Framework Core (SQL Server)
* **Security:** JWT Authentication, Role-based Access Control (RBAC)
* **Documentation:** Swagger / OpenAPI

## 📂 Project Structure

The project follows a modular structure to separate concerns:

* **API:** Controllers, Middleware, and API Configurations.
* **Core/Domain:** Entities, Interfaces, and Domain-specific logic.
* **Application:** DTOs, Business Services, and Mapping profiles.
* **Infrastructure:** Data access (DbContext), Migrations, and external service integrations.

## ⚙️ Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (Version 8.0 or later)
* SQL Server

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/mohamadhesham00/Byway-API.git](https://github.com/mohamadhesham00/Byway-API.git)
    cd Byway-API
    ```

2.  **Configure Environment:**
    Update the `appsettings.json` file in the API project with your database connection string and JWT settings:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=BywayDb;Trusted_Connection=True;"
    }
    ```

3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application:**
    ```bash
    dotnet run --project src/Byway/Byway.API
    ```

The API will be available at `https://localhost:5001` (or your configured port). You can explore and test the endpoints via the Swagger UI at `/swagger`.

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---
*Developed by [Mohamad Hesham](https://github.com/mohamadhesham00)*
