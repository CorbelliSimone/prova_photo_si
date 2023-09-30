using ProductsService.Service.Product.Dto;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsService.Service.Product
{
    /// <summary>
    /// Interfaccia per il servizio di gestione dei prodotti.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Ottiene tutti i prodotti in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutti i prodotti.</returns>
        Task<List<ProductDto>> GetAsync();

        /// <summary>
        /// Ottiene un prodotto per ID in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da ottenere.</param>
        /// <returns>Il prodotto con l'ID specificato.</returns>
        Task<ProductDto> GetAsync(int id);

        /// <summary>
        /// Aggiunge un nuovo prodotto in modo asincrono.
        /// </summary>
        /// <param name="productDto">DTO del prodotto da aggiungere.</param>
        /// <returns>Il DTO del prodotto aggiunto.</returns>
        Task<ProductDto> AddAsync(ProductDto productDto);

        /// <summary>
        /// Elimina un prodotto in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da eliminare.</param>
        /// <returns>Task completato.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Aggiorna un prodotto in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da aggiornare.</param>
        /// <param name="productDto">DTO del prodotto aggiornato.</param>
        /// <returns>Il numero di prodotti aggiornati.</returns>
        Task<int> UpdateAsync(int id, ProductDto productDto);
    }
}
