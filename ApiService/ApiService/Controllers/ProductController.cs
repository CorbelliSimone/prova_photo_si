using ApiService.Service.Httpz;
using ApiService.Service.Product;
using ApiService.Service.Product.Dto;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController
        (
            IProductService productService,
            UserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Oggetto richiesta inserimento prodotto arrivato nullo");
            try
            {
                await _productService.AddAsync(productDto);
                return Ok();
            }
            catch (BaseHttpClientException e)
            {
                return BadRequest($"Errroe inserimento prodotto {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
