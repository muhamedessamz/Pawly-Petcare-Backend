namespace PawlyPetCare.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string Role { get; set; } = "User"; // Admin, User
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        
        // OTP & Verification
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
