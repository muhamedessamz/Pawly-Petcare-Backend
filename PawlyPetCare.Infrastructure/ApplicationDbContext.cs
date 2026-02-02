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

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            
            // Seed Admin User
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "admin@pawly.com",
                PasswordHash = "admin", 
                Role = "Admin",
                Name = "Admin User",
                IsVerified = true 
            });

            // Seed Pets
            modelBuilder.Entity<Pet>().HasData(
                new Pet { 
                    Id = 1, Name = "Max", Type = "Dog", Breed = "Golden Retriever", Age = 2, Gender = "Male", Size = "Large", 
                    Location = "Cairo, Egypt", Status = "Approved", Traits = "Friendly, Energetic, Loyal", Weight = "30kg",
                    Image = "https://images.unsplash.com/photo-1552053831-71594a27632d?auto=format&fit=crop&q=80&w=800",
                    Description = "Max is a happy-go-lucky Golden Retriever who loves to swim and play fetch."
                },
                new Pet { 
                    Id = 2, Name = "Luna", Type = "Cat", Breed = "Persian", Age = 1, Gender = "Female", Size = "Small", 
                    Location = "Alexandria, Egypt", Status = "Approved", Traits = "Calm, Gentle, Affectionate", Weight = "4kg",
                    Image = "https://images.unsplash.com/photo-1514888286974-6c03e2ca1dba?auto=format&fit=crop&q=80&w=800",
                    Description = "Luna is a beautiful Persian cat with a very sweet and quiet personality."
                },
                new Pet { 
                    Id = 3, Name = "Rocky", Type = "Dog", Breed = "German Shepherd", Age = 3, Gender = "Male", Size = "Large", 
                    Location = "Giza, Egypt", Status = "Approved", Traits = "Protective, Intelligent, Active", Weight = "35kg",
                    Image = "https://images.unsplash.com/photo-1589941013453-ec89f33b5e95?auto=format&fit=crop&q=80&w=800",
                    Description = "Rocky is a highly intelligent German Shepherd who needs an active home."
                },
                new Pet { 
                    Id = 4, Name = "Milo", Type = "Dog", Breed = "Beagle", Age = 4, Gender = "Male", Size = "Medium", 
                    Location = "Cairo, Egypt", Status = "Approved", Traits = "Playful, Curious, Happy", Weight = "12kg",
                    Image = "https://images.unsplash.com/photo-1537151608828-ea2b11777ee8?auto=format&fit=crop&q=80&w=800",
                    Description = "Milo is a classic Beagle who loves sniffing out new adventures."
                },
                new Pet { 
                    Id = 5, Name = "Bella", Type = "Cat", Breed = "Siamese", Age = 2, Gender = "Female", Size = "Small", 
                    Location = "Mansoura, Egypt", Status = "Approved", Traits = "Vocal, Smart, Social", Weight = "3.5kg",
                    Image = "https://images.unsplash.com/photo-1513245543132-31f507417b26?auto=format&fit=crop&q=80&w=800",
                    Description = "Bella is a social Siamese cat who loves to be the center of attention."
                },
                new Pet { 
                    Id = 6, Name = "Charlie", Type = "Dog", Breed = "Poodle", Age = 1, Gender = "Male", Size = "Small", 
                    Location = "Cairo, Egypt", Status = "Approved", Traits = "Hypoallergenic, Elegant, Fun", Weight = "6kg",
                    Image = "https://images.unsplash.com/photo-1516734212186-a967f81ad0d7?auto=format&fit=crop&q=80&w=800",
                    Description = "Charlie is a charming little poodle who is great with children."
                }
            );
        }
    }
}
