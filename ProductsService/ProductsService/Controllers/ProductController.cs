using Microsoft.AspNetCore.Mvc;

using ProductsService.Service.Product;
using ProductsService.Service.Product.Dto;
using ProductsService.Service.Product.Exceptionz;

namespace ProductsService.Controllers
{
    /// <summary>
    /// Controller per la gestione dei prodotti.
    /// </summary>
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _categoryService;

        public ProductController(IProductService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Recupera tutti i prodotti.
        /// </summary>
        /// <returns>Una lista di prodotti.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAsync());
        }

        /// <summary>
        /// Recupera un prodotto tramite ID.
        /// </summary>
        /// <param name="id">L'ID del prodotto da recuperare.</param>
        /// <returns>Il prodotto con l'ID specificato.</returns>
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

        /// <summary>
        /// Aggiunge un nuovo prodotto.
        /// </summary>
        /// <param name="productDto">Il prodotto da aggiungere.</param>
        /// <returns>Il prodotto aggiunto.</returns>
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
                var createdResource = await _categoryService.AddAsync(productDto);
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

        /// <summary>
        /// Aggiorna un prodotto tramite ID.
        /// </summary>
        /// <param name="id">L'ID del prodotto da aggiornare.</param>
        /// <param name="productDto">Il prodotto con le modifiche.</param>
        /// <returns>Messaggio di conferma dell'aggiornamento.</returns>
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

        /// <summary>
        /// Elimina un prodotto tramite ID.
        /// </summary>
        /// <param name="id">L'ID del prodotto da eliminare.</param>
        /// <returns>Messaggio di conferma dell'eliminazione.</returns>
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
