# 🐾 Pawly Petcare - Backend API

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=json-web-tokens)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet)

**A robust, scalable, and secure RESTful API for the Pawly Petcare Platform.**

[Features](#-features) • [Getting Started](#-getting-started) • [API Documentation](#-api-documentation) • [Architecture](#-architecture)

</div>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Architecture](#-architecture)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
- [API Documentation](#-api-documentation)
- [Project Structure](#-project-structure)
- [Security](#-security)
- [Deployment](#-deployment)
- [License](#-license)

---

## 🎯 Overview

**Pawly Petcare API** is the backbone of the Pawly ecosystem, powering both the user-facing website and the administrative dashboard. It provides a comprehensive set of endpoints for managing pets, adoptions, products, orders, veterinary services, and blog content.

### 🎪 Key Capabilities

- **Pet Adoption**: seamless centralized system for managing pet profiles, adoption requests, and approvals.
- **E-Commerce**: Full product catalog, cart management, and order processing.
- **Veterinary Services**: Doctor profiles, appointment scheduling, and clinic management.
- **Content Management**: Blog system for sharing pet care tips and news.
- **Dashboard Analytics**: Real-time statistics for administrators.

---

## ✨ Features

### 🔐 Authentication & Authorization
- **JWT-based Authentication** regarding secure access.
- **Role-based Access Control** (Admin, User, Doctor).
- **Email Verification** with OTP support.
- **Secure Password Hashing**.

### 🐾 Pet & Adoption Management
- **Pet Profiles**: Comprehensive details (Breed, Age, Size, Traits).
- **Adoption Workflow**: Request submission, review, approval, and rejection.
- **Status Tracking**: Track pet status (Available, Pending, Adopted).
- **Owner Contact**: Secure communication channels for inquiries.

### 🛒 E-Commerce & Orders
- **Product Catalog**: Categorized products with images and details.
- **Order Processing**: Create orders with items, calculate totals.
- **Order History**: Users can view their past purchases.

### 🏥 Veterinary Services
- **Doctor Management**: Profiles, specialties, and availability.
- **Appointment Scheduling**: Book visits with vets.
- **Clinic Information**: Locations and contact details.

### 📝 Content & Administration
- **Blog System**: Create, update, and delete pet care articles.
- **Dashboard Stats**: Aggregated metrics on users, orders, and adoptions.
- **Admin Tools**: User management (create admins/doctors), product inventory, and more.

---

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Language**: C# 12.0
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server 2022
- **Authentication**: JWT (JSON Web Tokens)
- **Documentation**: Swagger/OpenAPI

### Architecture
- **Clean Architecture** (Separation of Concerns)
- **Repository Pattern** (via DbContext abstraction)
- **Dependency Injection**

---

## 🏗️ Architecture

The project follows **Clean Architecture** principles to ensure maintainability and scalability:

```
PawlyPetCare/
├── PawlyPetCare.Core/           # Domain Layer (Entities)
│   └── Entities/                # Database models (Pet, User, Product, etc.)
│
├── PawlyPetCare.Application/    # Application Layer (Business Logic)
│   ├── DTOs/                    # Data Transfer Objects
│   ├── Interfaces/              # Service contracts
│   └── Services/                # Service implementations
│
├── PawlyPetCare.Infrastructure/ # Infrastructure Layer (Data Access)
│   ├── ApplicationDbContext.cs  # EF Core Context
│   └── Migrations/              # Database Migrations
│
└── PawlyPetCare.API/            # Presentation Layer (API)
    ├── Controllers/             # API Endpoints
    └── Program.cs               # Startup & Configuration
```

---

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK**
- **SQL Server** (Local or Remote)
- **Visual Studio** or **VS Code**

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/muhamedessamz/Pawly-Petcare-Backend.git
   cd Pawly-Petcare-Backend
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure Database**
   Update `appsettings.json` in `PawlyPetCare.API` with your connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=PawlyDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. **Run Migrations**
   ```bash
   dotnet ef database update --project PawlyPetCare.Infrastructure --startup-project PawlyPetCare.API
   ```

5. **Start the API**
   ```bash
   dotnet run --project PawlyPetCare.API
   ```

---

## 📚 API Documentation

Once the application is running, you can access the interactive **Swagger UI** documentation:

```
https://localhost:7194/swagger
```
*(Note: Port number may vary based on your launch settings)*

### Core Endpoints

#### Pets
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pets` | Get available pets |
| POST | `/api/pets` | Create a new pet listing |
| POST | `/api/pets/approve/{id}` | Approve a pet listing (Admin) |
| POST | `/api/pets/reject/{id}` | Reject a pet listing (Admin) |

#### Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/login` | User login |
| POST | `/api/auth/register` | User registration |

#### Admin
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/admin/stats` | Get dashboard statistics |
| POST | `/api/admin/create-doctor` | Register a new doctor |

---

## 🔒 Security

- **JWT Auth**: All protected endpoints require a valid Bearer token.
- **CORS Policy**: Configured to allow requests from the trusted Frontend domain.
- **Input Validation**: DTO-based validation to ensure data integrity.
- **Sanitization**: Protection against common web vulnerabilities.

---

## 👨💻 Author

**Mohamed Essam**
- GitHub: [@muhamedessamz](https://github.com/muhamedessamz)

---

<div align="center">

**⭐ Star this repository if you find it helpful!**

Made with ❤️ for Pets

</div>
