using ApiService.Service.Httpz;

namespace ApiService.Service.Product.Httpz
{
    /// <summary>
    /// Implementazione del client HTTP per le operazioni relative ai prodotti.
    /// Deriva dalla classe base <see cref="BaseHttpClient"/> e implementa l'interfaccia <see cref="IProductHttpClient"/>.
    /// </summary>
    public class ProductHttpClient : BaseHttpClient, IProductHttpClient
    {
        /// <summary>
        /// Inizializza una nuova istanza del client HTTP per i prodotti.
        /// </summary>
        /// <param name="httpClient">Client HTTP da utilizzare per le richieste.</param>
        public ProductHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/product/")
        {
        }
    }
}
