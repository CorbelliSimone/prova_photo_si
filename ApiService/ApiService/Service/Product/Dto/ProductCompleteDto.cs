namespace ApiService.Service.Product.Dto
{
    /// <summary>
    /// Rappresenta i dettagli completi di un prodotto.
    /// </summary>
    public class ProductCompleteDto
    {
        /// <summary>
        /// Ottiene o imposta il nome del prodotto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ottiene o imposta la descrizione del prodotto.
        /// </summary>
        public string Description { get; set; }
    }
}
