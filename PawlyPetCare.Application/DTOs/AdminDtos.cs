namespace PawlyPetCare.Application.DTOs
{
    public class CreateAdminDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Admin, SuperAdmin
    }

    public class CreateDoctorAdminDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Experience { get; set; }
    }

    public class AdminResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsVerified { get; set; }
    }

    public class DashboardStatsDto
    {
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public int TotalAppointments { get; set; }
        public int TotalUsers { get; set; }
        public int PendingAppointments { get; set; }
        public int ProcessingOrders { get; set; }
    }
}
