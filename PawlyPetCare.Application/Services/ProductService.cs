using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                PetType = dto.PetType,
                Image = dto.Image,
                Stock = dto.Stock > 0 ? dto.Stock : 100, // Reasonable default
                Rating = 0,
                ReviewCount = 0
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Category = dto.Category;
            product.PetType = dto.PetType;
            if (dto.Image != null) product.Image = dto.Image;
            if (dto.Stock.HasValue) product.Stock = dto.Stock.Value;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
