namespace ProductsService.Service.Product.Dto
{
    /// <summary>
    /// DTO (Data Transfer Object) per rappresentare un prodotto.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// ID del prodotto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID della categoria a cui il prodotto appartiene.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome del prodotto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrizione del prodotto.
        /// </summary>
        public string Description { get; set; }
    }
}
