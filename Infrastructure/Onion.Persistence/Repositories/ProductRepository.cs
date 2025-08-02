using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IRepository<Product>
    {
        public async Task<List<Product>> GetAllProducstWithCategories()
        {
            var products = await context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            if (products is null || products.Count == 0)
            {
                throw new InvalidOperationException("No products found with categories.");
            }
            return products;
        }

        public async Task<Product> GetProductByIdWithCategory(Guid id)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                throw new InvalidOperationException($"Product with ID {id} not found.");
            }

            return product;
        }


    }
}
