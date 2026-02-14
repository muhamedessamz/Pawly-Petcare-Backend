# Pawly Petcare - Project Structure Documentation

This document provides a detailed overview of the **Pawly Petcare** project structure, covering both the Frontend (Client & Dashboard) and Backend (API).

## 📂 Project Root
`c:\Users\muham\Desktop\Main Projects\pawly-petcare`

The project is divided into two main sections:
- **Pawly-Frontend**: Contains the user-facing website and the admin dashboard.
- **Pawly-Backend**: Contains the trusted API built with .NET 8 (Clean Architecture).

---

## 🖥️ Frontend Structure (`Pawly-Frontend`)

The frontend is a monorepo-style setup containing two separate React applications built with **Vite**.

### 1. Main Website (`/Main`)
This is the customer-facing application where users can view pets, products, blogs, and services.

**Key Directories:**
- **`src/`**: Source code root.
    - **`assets/`**: Static assets like images and global styles.
    - **`components/`**: Reusable UI components (e.g., Navbar, Footer, Buttons).
    - **`context/`**: React Context for global state management (e.g., AuthContext, ShopContext).
    - **`pages/`**: specific pages mapping to routes (e.g., `Home.jsx`, `Pets.jsx`, `Shop.jsx`).
    - **`services/`**: API integration logic (Axios setup to communicate with Backend).
    - **`utils/`**: Helper functions and constants.
    - **`App.jsx`**: Main application component defining routes.
    - **`main.jsx`**: Entry point rendering the React app.

**Tech Stack:** React, Vite, TailwindCSS, Lucide React (Icons), React Router DOM.

### 2. Admin Dashboard (`/Dashboard`)
This is the administrative panel for managing the platform (Pets, Users, Products, etc.).

**Key Directories:**
- **`src/`**: Source code root.
    - **`layouts/`**: Layout wrappers (e.g., SidebarLayout) for dashboard pages.
    - **`pages/`**: Admin views (e.g., `DashboardHome`, `ManagePets`, `ManageUsers`).
    - **`services/`**: API service calls specific to admin actions.
    - **`lib/`**: Utility libraries.
    - **`App.jsx`**: Main routing configuration for the dashboard.

**Tech Stack:** React, Vite, TailwindCSS, Recharts (for charts), Axios.

---

## ⚙️ Backend Structure (`Pawly-Backend`)

The backend follows **Clean Architecture** principles, separating concerns into four specific projects.

### 1. API Layer (`PawlyPetCare.API`)
The entry point of the application. It handles HTTP requests and responses.

- **`Controllers/`**: REST API Endpoints (e.g., `PetsController`, `AuthController`).
- **`Program.cs`**: Application startup, Dependency Injection configuration, Database connection, and Middleware setup.
- **`appsettings.json`**: Configuration file (Connection Strings, JWT keys).
- **`wwwroot/`**: Static files folder (used for serving uploaded images).

### 2. Application Layer (`PawlyPetCare.Application`)
Contains the business logic and rules of the application. It depends only on the Domain layer.

- **`DTOs/`** (Data Transfer Objects): Objects used to pass data between the API and Client (e.g., `LoginDto`, `CreatePetDto`).
- **`Interfaces/`**: Abstractions for services (e.g., `IPetService`, `IAuthService`).
- **`Services/`**: Implementation of business logic (e.g., `PetService`, `AuthService`).

### 3. Infrastructure Layer (`PawlyPetCare.Infrastructure`)
Handles external concerns like Database connectivity and file storage.

- **`ApplicationDbContext.cs`**: The EF Core database context class managing tables.
- **`Migrations/`**: Code-first migrations to create/update the database schema.
- **`Repositories/`**: (If used) Data access implementations.

### 4. Domain Layer (`PawlyPetCare.Domain`)
The core of the application involving enterprise logic and entities. It has NO dependencies.

- **`Entities/`**: Database models representing tables (e.g., `Pet`, `User`, `Product`, `Appointment`).

---

## 🚀 Key Workflows

### API Communication
- **Frontend** uses `axios` (configured in `src/services/api.js`) to make requests.
- **Backend** exposes endpoints via **Controllers** (e.g., `api/pets`, `api/auth`).
- **CORS** policies in `Program.cs` allow the Frontend to communicate with the Backend.

### Database
- Uses **SQL Server**.
- Managed via **Entity Framework Core**.
- Connection string is located in `appsettings.json`.

### Authentication
- Uses **JWT (JSON Web Tokens)** if configured (currently undergoing setup).
- `AuthService` handles Login/Register logic.
