using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Suppress warnings that are treated as errors
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }

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
                    Location = "New York, NY", Status = "Approved", Traits = "Friendly, Energetic, Loyal", Weight = "30kg",
                    Image = "https://images.unsplash.com/photo-1552053831-71594a27632d?auto=format&fit=crop&q=80&w=800",
                    Description = "Max is a happy-go-lucky Golden Retriever who loves to swim and play fetch.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 010-1010"
                },
                new Pet { 
                    Id = 2, Name = "Luna", Type = "Cat", Breed = "Persian", Age = 1, Gender = "Female", Size = "Small", 
                    Location = "Los Angeles, CA", Status = "Approved", Traits = "Calm, Gentle, Affectionate", Weight = "4kg",
                    Image = "https://images.unsplash.com/photo-1514888286974-6c03e2ca1dba?auto=format&fit=crop&q=80&w=800",
                    Description = "Luna is a beautiful Persian cat with a very sweet and quiet personality.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 020-2020"
                },
                new Pet { 
                    Id = 3, Name = "Rocky", Type = "Dog", Breed = "German Shepherd", Age = 3, Gender = "Male", Size = "Large", 
                    Location = "Chicago, IL", Status = "Approved", Traits = "Protective, Intelligent, Active", Weight = "35kg",
                    Image = "https://images.unsplash.com/photo-1589941013453-ec89f33b5e95?auto=format&fit=crop&q=80&w=800",
                    Description = "Rocky is a highly intelligent German Shepherd who needs an active home.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 030-3030"
                },
                new Pet { 
                    Id = 4, Name = "Milo", Type = "Dog", Breed = "Beagle", Age = 4, Gender = "Male", Size = "Medium", 
                    Location = "Seattle, WA", Status = "Approved", Traits = "Playful, Curious, Happy", Weight = "12kg",
                    Image = "https://images.unsplash.com/photo-1537151608828-ea2b11777ee8?auto=format&fit=crop&q=80&w=800",
                    Description = "Milo is a classic Beagle who loves sniffing out new adventures.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 040-4040"
                },
                new Pet { 
                    Id = 5, Name = "Bella", Type = "Cat", Breed = "Siamese", Age = 2, Gender = "Female", Size = "Small", 
                    Location = "Austin, TX", Status = "Approved", Traits = "Vocal, Smart, Social", Weight = "3.5kg",
                    Image = "https://images.unsplash.com/photo-1513245543132-31f507417b26?auto=format&fit=crop&q=80&w=800",
                    Description = "Bella is a social Siamese cat who loves to be the center of attention.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 050-5050"
                },
                new Pet { 
                    Id = 6, Name = "Charlie", Type = "Dog", Breed = "Poodle", Age = 1, Gender = "Male", Size = "Small", 
                    Location = "Boston, MA", Status = "Approved", Traits = "Hypoallergenic, Elegant, Fun", Weight = "6kg",
                    Image = "https://images.unsplash.com/photo-1516734212186-a967f81ad0d7?auto=format&fit=crop&q=80&w=800",
                    Description = "Charlie is a charming little poodle who is great with children.",
                    OwnerEmail = "adopt@pawly.com", OwnerPhone = "+1 (555) 060-6060"
                }
            );

            // Seed Clinic
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    Id = 1,
                    Name = "Pawly Main Clinic",
                    Address = "Main Health Plaza, Suite 400",
                    City = "New York",
                    State = "NY",
                    ZipCode = "11201",
                    PhoneNumber = "+1 (555) 123-4567",
                    Description = "World-Class Care For Your Best Friend. Specialized veterinarians, modern equipment, and 24/7 care."
                }
            );

            // Seed Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Richard Hamilton",
                    Specialty = "Senior Veterinary Surgeon",
                    Image = "https://img.freepik.com/free-photo/close-up-health-worker_23-2149112506.jpg?t=st=1769968108~exp=1769971708~hmac=776163d86f26ae815d19154eb6dbe230a0e53b173b9720bffdc9e4a243b970a1",
                    Rating = 4.9,
                    ExperienceYears = 15,
                    Location = "Pawly Main Clinic",
                    Availability = "Mon,Wed,Fri,Sat",
                    ClinicId = 1
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Dr. Isabella Rossi",
                    Specialty = "Dermatology & Allergy Specialist",
                    Image = "https://img.freepik.com/free-photo/female-doctor-hospital-with-stethoscope_23-2148827776.jpg?semt=ais_hybrid&w=740&q=80",
                    Rating = 5.0,
                    ExperienceYears = 10,
                    Location = "Pawly Main Clinic",
                    Availability = "Tue,Thu,Fri",
                    ClinicId = 1
                },
                new Doctor
                {
                    Id = 3,
                    Name = "Dr. James Sterling",
                    Specialty = "Dental & Oral Surgery",
                    Image = "https://img.freepik.com/free-photo/close-up-health-worker_23-2149112576.jpg?t=st=1769968157~exp=1769971757~hmac=cef906f5b4c3c4931da10ccbb42c3abb3f1dbff106c2d5b7b947cd2fc315c042",
                    Rating = 4.8,
                    ExperienceYears = 12,
                    Location = "Pawly Main Clinic",
                    Availability = "Mon,Tue,Thu",
                    ClinicId = 1
                },
                new Doctor
                {
                    Id = 4,
                    Name = "Dr. Elena Petrova",
                    Specialty = "Exotic Animal Specialist",
                    Image = "https://img.freepik.com/free-photo/portrait-beautiful-young-female-doctor_329181-1163.jpg?t=st=1769968709~exp=1769972309~hmac=f14363b73f0cfa29201dfd812bb25548db7a9596a4630cccf38494b50bd498cf&w=1480",
                    Rating = 4.9,
                    ExperienceYears = 9,
                    Location = "Pawly Main Clinic",
                    Availability = "Wed,Sat,Sun",
                    ClinicId = 1
                }
            );
        }
    }
}
