using ApiService.Service.Httpz;
using ApiService.Service.Product;
using ApiService.Service.User.Cache;

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
            IUserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            _productService = productService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _productService.DeleteAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _productService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _productService.GetAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] object productDto)
        {
            if (productDto == null)
            {
                return BadRequest("dati prodotto da modificare arrivati nulli");
            }

            if (id < 1)
            {
                return BadRequest("Id prodotto minore di 1");
            }

            try
            {
                var productResult = await _productService.PutAsync(id, productDto);
                return Ok(productResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object productDto)
        {
            if (productDto == null)
                return BadRequest("Oggetto richiesta inserimento prodotto arrivato nullo");
            try
            {
                var insertedProduct = await _productService.AddAsync(productDto);
                return Ok(insertedProduct);
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
