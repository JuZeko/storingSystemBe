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

        public async Task<List<Product>> GetAllProducts(string productType)
        {
            return await _context.Product.Where(product => product.productType == productType).ToListAsync();
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

        public async Task<Product>? UpdateProductAsync(Product product)
        {
            var dbClient = await _context.
                Product.SingleOrDefaultAsync(productElement => productElement.Id == product.Id);
            if (dbClient == null) return null;

            dbClient.productType = product.productType;
            dbClient.Name = product.Name;

            await _context.SaveChangesAsync();
            return dbClient;
        }

        public Task<Product>? GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
