using ecommerceEngine.Domain.Entities;
using ecommerceEngine.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ecommerceEngine.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product ?? throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        public async Task<Product> AddAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _db.Products.FindAsync(product.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {product.Id} not found");

            // Update properties
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found");

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}
