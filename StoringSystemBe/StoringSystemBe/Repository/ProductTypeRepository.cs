using Microsoft.EntityFrameworkCore;
using StoringSystemBe.Data;
using StoringSystemBe.Model;

namespace StoringSystemBe.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly StoringSystemDbContext _context;

        public ProductTypeRepository(StoringSystemDbContext context)
        {
            _context = context;
        }

        public async Task<ProductType> AddProductType(ProductType productType)
        {
           await _context.ProductTypes.AddAsync(productType);
           await _context.SaveChangesAsync();

           return productType;
        }

        public async Task<ProductType> DeleteProductType(int id)
        {
            var client = _context.ProductTypes.FirstOrDefault(x => x.Id == id);
            if (client != null)
            {
                 _context.ProductTypes.Remove(client);
                await _context.SaveChangesAsync();
                return client;
            }
            return null;
        }

        public async Task<List<ProductType>> GetAllProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }

    }
}
