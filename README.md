# 🐾 Pawly Petcare - Backend API

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=json-web-tokens)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger)

**A comprehensive, enterprise-grade RESTful API powering the Pawly Petcare Platform.**

[Features](#-features) • [Getting Started](#-getting-started) • [API Documentation](#-api-documentation) • [Architecture](#-architecture) • [Contributing](#-contributing)

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
  - [Configuration](#configuration)
  - [Database Setup](#database-setup)
- [API Documentation](#-api-documentation)
- [Project Structure](#-project-structure)
- [Security](#-security)
- [Performance Optimizations](#-performance-optimizations)
- [Testing](#-testing)
- [Deployment](#-deployment)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🎯 Overview

**Pawly Petcare API** is a robust, scalable, and secure backend solution designed to manage the entire lifecycle of pet adoption and veterinary services. Built with modern software engineering principles, it provides a seamless experience for users, doctors, and administrators.

### 🎪 Problem It Solves

- **Fragmented Adoption Process**: Centralizes pet listings, applications, and approvals.
- **Lost Medical Records**: detailed profiles for doctors and clinics.
- **E-Commerce Complexity**: Manages products, orders, and inventory in one place.
- **Content Delivery**: Serves educational blog content to pet owners.

### 👥 Target Users

- **Pet Adopters**: Browse and urge to adopt pets.
- **Veterinarians**: Manage profiles and view appointments.
- **Administrators**: Oversee the entire platform via a dedicated dashboard.

---

## ✨ Features

### 🔐 Authentication & Authorization
- **JWT-based Authentication** with secure token management.
- **Role-based Access Control** (Admin, User, Doctor).
- **Email Verification** with OTP (One-Time Password).
- **Secure Password Hashing** (BCrypt/Argon2 via Identity).

### 🐾 Pet & Adoption Management
- **CRUD Operations** for pet listings.
- **Status Tracking** (Available, Pending, Adopted).
- **Rich Media**: Support for pet image URLs and details.
- **Adoption Workflow**: Request submission, admin review, and approval/rejection logic.

### 🛒 E-Commerce & Orders
- **Product Catalog** with categories and filtering.
- **Order Management**: Create, track, and view order history.
- **Inventory Control**: Automatic stock adjustments.

### 🏥 Veterinary Services
- **Doctor Profiles**: Specialties, experience, and contact info.
- **Clinic Management**: Locations and service details.
- **Appointment Scheduling**: Booking system for user-doctor interactions.

### 📊 Admin Dashboard
- **Real-time Statistics**: Users, Orders, Adoptions, and Revenue.
- **Content Management**: Blog post creation and editing.
- **User Management**: Promote users to admins or doctors.

---

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Language**: C# 12.0
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server 2022
- **Authentication**: JWT (JSON Web Tokens)
- **Documentation**: Swagger/OpenAPI
- **Logging**: Microsoft.Extensions.Logging

### Architecture & Patterns
- **Clean Architecture** (Separation of Concerns)
- **Repository Pattern** (via DbContext abstraction)
- **Dependency Injection** for loose coupling
- **DTO Pattern** for data transfer
- **Service Layer** for business logic isolation

---

## 🏗️ Architecture

The project follows **Clean Architecture** principles with clear separation of concerns:

```
PawlyPetCare/
├── PawlyPetCare.Domain/         # Domain Layer
│   └── Entities/                # Database models (Pet, User, Product)
│
├── PawlyPetCare.Application/    # Application Layer
│   ├── DTOs/                    # Data Transfer Objects
│   ├── Interfaces/              # Service contracts
│   └── Services/                # Business logic implementations
│
├── PawlyPetCare.Infrastructure/ # Infrastructure Layer
│   ├── Data/                    # DbContext & configurations
│   └── Migrations/              # Database schema migrations
│
└── PawlyPetCare.API/            # Presentation Layer
    ├── Controllers/             # API Endpoints
    ├── Program.cs               # Startup configuration
    └── appsettings.json         # Configuration settings
```

---

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 8.0 SDK** ([Download](https://dotnet.microsoft.com/download))
- **SQL Server** (Local or Cloud)
- **Visual Studio** or **VS Code**

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/muhamedessamz/Pawly-Petcare-Backend.git
   cd Pawly-Petcare-Backend
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Navigate to the API project**
   ```bash
   cd PawlyPetCare.API
   ```

### Configuration

Update the `appsettings.json` file with your database connection string and JWT settings.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PawlyDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "JwtSettings": {
    "SecretKey": "YOUR_SUPER_SECRET_KEY_MUST_BE_LONG_ENOUGH",
    "Issuer": "PawlyAPI",
    "Audience": "PawlyClient"
  }
}
```

### Database Setup

1. **Apply migrations** to create the database schema:
   ```bash
   dotnet ef database update --project ../PawlyPetCare.Infrastructure
   ```

2. **Start the API**:
   ```bash
   dotnet run
   ```

---

## 📚 API Documentation

### Base URL
```
https://localhost:7194/api
```

### Authentication Flow

#### 1. Register a New User
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "Password123!",
  "name": "John Doe"
}
```

#### 2. Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "Password123!"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "email": "user@example.com",
  "role": "User"
}
```

### Core Endpoints

#### Pets

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/pets` | Get approved pets | ❌ |
| GET | `/api/pets/{id}` | Get pet details | ❌ |
| POST | `/api/pets` | List a new pet | ✅ |
| POST | `/api/pets/approve/{id}` | Approve listing | ✅ (Admin) |
| POST | `/api/pets/reject/{id}` | Reject listing | ✅ (Admin) |

#### Products

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/products` | Get all products | ❌ |
| POST | `/api/admin/products` | Add product | ✅ (Admin) |

#### Orders

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/order` | Create an order | ✅ |
| GET | `/api/order/my-orders` | Get user history | ✅ |

### Request Example: Creating a Pet

```http
POST /api/pets
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "Buddy",
  "type": "Dog",
  "breed": "Golden Retriever",
  "age": 2,
  "gender": "Male",
  "size": "Large",
  "location": "New York, NY",
  "description": "Friendly and energetic dog.",
  "image": "https://example.com/buddy.jpg",
  "ownerEmail": "owner@example.com",
  "ownerPhone": "+1234567890"
}
```

---

## 🔒 Security

### Best Practices Implemented

1. **HTTPS Enforcement**: All traffic is encrypted.
2. **CORS Configuration**: Restricts access to trusted frontend headers.
3. **Parameter Validation**: Input is validated using Data Annotations (DTOs).
4. **SQL Injection Protection**: Uses Entity Framework Core parameterization.
5. **Cross-Site Scripting (XSS)**: Input sanitization handled by framework.

---

## ⚡ Performance Optimizations

1. **Async/Await**: Non-blocking I/O for high throughput.
2. **Entity Framework Efficiency**:
   - `AsNoTracking()` used for read-only queries.
   - Selective column retrieval (`Select`) to minimize data transfer.
3. **Database Indexing**: Optimized queries for common lookups.

---

## 🧪 Testing

Run unit and integration tests using the .NET CLI:

```bash
dotnet test
```

---

## 🚢 Deployment

### Docker Support

build the image:
```bash
docker build -t pawly-api .
```

Run the container:
```bash
docker run -p 8080:80 -e "ConnectionStrings:DefaultConnection=..." pawly-api
```

### Azure App Service

1. Publish the app:
   ```bash
   dotnet publish -c Release
   ```
2. Deploy the `publish` folder to Azure Web App via FTP or GitHub Actions.

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/NewFeature`).
3. Commit your changes.
4. Push to the branch.
5. Open a Pull Request.

---

## 📄 License

This project is licensed under the **MIT License**.

---

## 👨💻 Author

**Mohamed Essam**
- GitHub: [@muhamedessamz](https://github.com/muhamedessamz)
- LinkedIn: [Mohamed Essam](https://www.linkedin.com/in/mohamedessamz/)

---

<div align="center">

**⭐ Star this repository if you find it helpful!**

Made with ❤️ for Pets

</div>
