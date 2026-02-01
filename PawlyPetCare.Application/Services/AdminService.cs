using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        // User Management
        public async Task<AdminResponseDto> CreateAdminAsync(CreateAdminDto dto)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                throw new Exception("User with this email already exists");
            }

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = dto.Password, // In production, hash this!
                Name = dto.Name,
                Role = dto.Role,
                IsVerified = true // Auto-verify admin users
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AdminResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                IsVerified = user.IsVerified
            };
        }

        public async Task<AdminResponseDto> CreateDoctorAdminAsync(CreateDoctorAdminDto dto)
        {
            // Create user with Admin role
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = dto.Password,
                Name = dto.Name,
                Role = "Admin",
                IsVerified = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Create doctor entry
            var doctor = new Doctor
            {
                Name = dto.Name,
                Specialty = dto.Specialty,
                ExperienceYears = dto.Experience,
                Location = "Clinic", // Default location
                Image = "/images/doctors/default.jpg" // Default image
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return new AdminResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                IsVerified = user.IsVerified
            };
        }

        public async Task<List<AdminResponseDto>> GetAllAdminsAsync()
        {
            var admins = await _context.Users
                .Where(u => u.Role == "Admin" || u.Role == "SuperAdmin")
                .Select(u => new AdminResponseDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    Role = u.Role,
                    IsVerified = u.IsVerified
                })
                .ToListAsync();

            return admins;
        }

        // Statistics
        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var stats = new DashboardStatsDto
            {
                TotalProducts = await _context.Products.CountAsync(),
                TotalOrders = await _context.Orders.CountAsync(),
                TotalAppointments = await _context.Appointments.CountAsync(),
                TotalUsers = await _context.Users.Where(u => u.Role == "User").CountAsync(),
                PendingAppointments = await _context.Appointments.CountAsync(a => a.Status == "Pending"),
                ProcessingOrders = await _context.Orders.CountAsync(o => o.Status == "Processing")
            };

            return stats;
        }

        // Product Management
        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto, string? imagePath)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                PetType = dto.PetType,
                Image = imagePath,
                Stock = 100, // Default stock
                Rating = 0,
                ReviewCount = 0
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                PetType = product.PetType,
                ImageUrl = product.Image
            };
        }

        public async Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductDto dto, string? imagePath)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Category = dto.Category;
            product.PetType = dto.PetType;

            if (imagePath != null)
            {
                product.Image = imagePath;
            }

            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                PetType = product.PetType,
                ImageUrl = product.Image
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category,
                    PetType = p.PetType,
                    ImageUrl = p.Image
                })
                .ToListAsync();

            return products;
        }
    }
}
