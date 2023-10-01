using ApiService.Service.Httpz;
using ApiService.Service.Product;
using ApiService.Service.Product.Exceptionz;
using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// Controller per gestire le operazioni relative ai prodotti.
    /// </summary>
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="ProductController"/>.
        /// </summary>
        /// <param name="productService">Servizio per la gestione dei prodotti.</param>
        /// <param name="userLoggedHandler">Handler per l'utente loggato.</param>
        public ProductController
        (
            IProductService productService,
            IUserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            _productService = productService;
        }

        /// <summary>
        /// Elimina un prodotto per ID.
        /// </summary>
        /// <param name="id">ID del prodotto da eliminare.</param>
        /// <returns>Risposta HTTP che indica l'esito dell'operazione di eliminazione.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Impossibile eliminare prodotto con id {id}");
            }

            try
            {
                return Ok(await _productService.DeleteAsync(id));
            }
            catch (ProductException e)
            {
                return BadRequest($"Eerrore eliminazione prodotto {id}: {e.Message}");
            }
        }

        /// <summary>
        /// Ottiene tutti i prodotti.
        /// </summary>
        /// <returns>Risposta HTTP con i prodotti.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _productService.GetAsync());

        /// <summary>
        /// Ottiene un prodotto per ID.
        /// </summary>
        /// <param name="id">ID del prodotto.</param>
        /// <returns>Risposta HTTP con il prodotto corrispondente all'ID specificato.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _productService.GetAsync(id));

        /// <summary>
        /// Aggiorna un prodotto.
        /// </summary>
        /// <param name="id">ID del prodotto da aggiornare.</param>
        /// <param name="productDto">Dati del prodotto da aggiornare.</param>
        /// <returns>Risposta HTTP con il prodotto aggiornato.</returns>
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

        /// <summary>
        /// Crea un nuovo prodotto.
        /// </summary>
        /// <param name="productDto">Dati del nuovo prodotto.</param>
        /// <returns>Risposta HTTP con il prodotto creato.</returns>
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
