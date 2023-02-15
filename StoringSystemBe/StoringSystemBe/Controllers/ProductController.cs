using Microsoft.AspNetCore.Mvc;
using StoringSystemBe.Model;
using StoringSystemBe.Repository;

namespace ntsystbe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("create")]
        public async Task<List<Product>?> AddContractAsync(Product product) => await _productRepository.AddProductAsync(product);

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Product>>> GetAllContractAsync() => new OkObjectResult(await _productRepository.GetAllProducts());

        [HttpDelete("delete")]
        public async Task<List<Product>?> DeleteContract([FromBody] int id) => await _productRepository.DeleteProduct(id);

        [HttpPut("update")]
        public async Task<List<Product>?> UpdateContract(Product request) => await _productRepository.UpdateProductAsync(request);
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetContractAsync(int id) => new OkObjectResult(await _productRepository.GetProduct(id));
    }
}

