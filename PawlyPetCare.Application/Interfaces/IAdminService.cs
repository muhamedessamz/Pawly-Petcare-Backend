using PawlyPetCare.Application.DTOs;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IAdminService
    {
        // User Management
        Task<AdminResponseDto> CreateAdminAsync(CreateAdminDto dto);
        Task<AdminResponseDto> CreateDoctorAdminAsync(CreateDoctorAdminDto dto);
        Task<List<AdminResponseDto>> GetAllAdminsAsync();
        
        // Statistics
        Task<DashboardStatsDto> GetDashboardStatsAsync();
        
        // Product Management
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto, string? imagePath);
        Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductDto dto, string? imagePath);
        Task<bool> DeleteProductAsync(int id);
        Task<List<ProductResponseDto>> GetAllProductsAsync();
    }
}
