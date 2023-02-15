using Microsoft.AspNetCore.Mvc;
using StoringSystemBe.Model;
using StoringSystemBe.Repository;

namespace ntsystbe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository clientRepository)
        {
            _productTypeRepository = clientRepository;
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductType))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getAll")]
        public async Task<ActionResult<List<ProductType>>> GetAllProductsAsync() => new OkObjectResult(await _productTypeRepository.GetAllProductTypes());



        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductType))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("addProductType")]
        public async Task<ActionResult<ProductType>> AddProductAsync([FromBody] ProductType productType)
        {
            return new OkObjectResult(await _productTypeRepository.AddProductType(productType));
        }


    }
}
