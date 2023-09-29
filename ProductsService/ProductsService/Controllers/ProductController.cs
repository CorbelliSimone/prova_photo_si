using Microsoft.AspNetCore.Mvc;

using ProductsService.Service.Product;
using ProductsService.Service.Product.Dto;
using ProductsService.Service.Product.Exceptionz;

namespace ProductsService.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _categoryService;

        public ProductController
        (
            IProductService categoryService
        )
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido {id}");
            }

            ProductDto productDto = await _categoryService.GetAsync(id);
            return productDto == null ? NoContent() : Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Prodotto per inserimento arrivato nullo");
            }

            if (productDto.CategoryId < 1)
            {
                return BadRequest($"Categoria {productDto.CategoryId} non valida");
            }

            try
            {
                ProductDto createdResource = await _categoryService.AddAsync(productDto);
                return Created("", createdResource);
            }
            catch (ProductException e)
            {
                return BadRequest($"Errore inserimento prodotto {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto productDto)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            if (productDto == null)
            {
                return BadRequest("Prodotto arrivato nullo");
            }

            try
            {
                int saveStatus = await _categoryService.UpdateAsync(id, productDto);
                return Ok($"Prodotto {id} aggiornato con successo {saveStatus}");
            }
            catch (ProductException e)
            {
                return BadRequest($"Errroe aggiornamento prodotto {id} {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore aggiornato prodotto: {id} {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            try
            {
                await _categoryService.DeleteAsync(id);
                return Ok($"Prodotto {id} eliminato con successo");
            }
            catch (ProductException e)
            {
                return BadRequest($"Errore eliminazione prodotto {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore richiesta id: {id} {e.Message}");
            }
        }
    }
}
