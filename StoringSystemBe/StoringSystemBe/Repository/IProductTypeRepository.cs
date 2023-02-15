using Microsoft.AspNetCore.Mvc;
using StoringSystemBe.Model;

namespace StoringSystemBe.Repository
{
    public interface IProductTypeRepository
    {
        Task<List<ProductType>> GetAllProductTypes();
        Task<ProductType> AddProductType(ProductType client);
        Task<ProductType> DeleteProductType(int id);
    }
}
