
# CRUD Operations For Courses Management System

This is a web-based platform built using **ASP.NET Core MVC** and **Entity Framework Core** (Code First approach). It provides **CRUD operations** for managing Courses, Departments, and Students. The project includes authentication features such as login, registration, and logout, allowing users to manage platform data securely.

## Features

### 1. CRUD Operations
- **Courses**
  - Add new courses.
  - Edit existing courses.
  - Delete courses (with soft delete where applicable).
  - View a list of all courses (Index).
  - View details for each course.

- **Departments**
  - Create new departments.
  - Update department information.
  - Delete departments.
  - View a list of all departments.
  - View detailed information about a department.

- **Students**
  - Register new students.
  - Edit student profiles.
  - Remove students.
  - View a list of all students.
  - View detailed student information.

### 2. User Authentication
- **Register**: Users can create a new account.
- **Login**: Registered users can log in to access the platform.
- **Logout**: Users can log out of their account.
- Role-based authorization is implemented to control access to different parts of the system.

### 3. Database Management
- The project follows a **Code First** approach using **Entity Framework Core**, which automatically generates the database schema based on the model classes.
- You can apply migrations to update the database schema as the project evolves.


## Usage

1. **Register** a new user or **log in** with existing credentials.
2. Navigate to the **Courses**, **Departments**, or **Students** section to manage data.
3. Perform actions like **Create**, **Edit**, **Delete**, and **View Details** for each entity.

## Built With

- **ASP.NET Core MVC**: For building web applications.
- **Entity Framework Core**: For database interaction.
- **SQL Server**: As the database engine.
- **Bootstrap**: For responsive UI design.
- **C#**: As the primary programming language.



