using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoringSystemBe.Data;
using StoringSystemBe.Model;

namespace StoringSystemBe.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoringSystemDbContext _context;

        public ProductRepository(StoringSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var dbContract = await _context.Product.FindAsync(id);
            if (dbContract == null)
                return null;

            _context.Product.Remove(dbContract);
            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }

        public async Task<List<Product>?> AddProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Product.ToListAsync();
        }
        public async Task<Product> GetContract(int id)
        {
            var dbContract = await _context.Product.FindAsync(id);
            if (dbContract == null) return null;

            return dbContract;
        }

        public async Task<List<Product>?> UpdateProductAsync(Product contract)
        {


            return null;
        }

        public Task<Product>? GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
