using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
    }
}
