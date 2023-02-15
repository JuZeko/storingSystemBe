using Microsoft.AspNetCore.Mvc;
using StoringSystemBe.Model;

namespace StoringSystemBe.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts(string productType);

        Task<List<Product>?> DeleteProduct(int id);

        Task<List<Product>?> AddProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);
        Task<Product>? GetProduct(int id);
    }
}
