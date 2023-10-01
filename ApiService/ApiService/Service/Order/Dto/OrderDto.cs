namespace ApiService.Service.Order.Dto
{
    /// <summary>
    /// Data transfer object per un ordine.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// ID dell'ordine.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID dell'utente associato all'ordine.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID dell'indirizzo associato all'ordine.
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Nome dell'ordine.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Elenco dei prodotti nell'ordine.
        /// </summary>
        public List<ProductDto> Products { get; set; }
    }

    /// <summary>
    /// Data transfer object per un prodotto.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// ID del prodotto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Quantità del prodotto.
        /// </summary>
        public int Quantity { get; set; }
    }
}
