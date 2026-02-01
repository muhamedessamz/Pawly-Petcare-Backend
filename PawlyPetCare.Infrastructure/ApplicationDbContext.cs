using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            
            // Seed Admin User
            // Password: admin (Ideally hash it properly, simple hash for demo)
            // In real app use Identity or BCrypt
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "admin@pawly.com",
                PasswordHash = "admin", 
                Role = "Admin",
                Name = "Admin User",
                IsVerified = true // Allow admin to login without OTP verification
            });
        }
    }
}
