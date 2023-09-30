namespace OrdersService.Service.Order.Dto
{
    /// <summary>
    /// DTO (Data Transfer Object) per rappresentare un ordine.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// ID dell'ordine.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numero dell'ordine.
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Nome dell'ordine.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Prodotti associati all'ordine.
        /// </summary>
        public List<ProductDto> Products { get; set; }

        /// <summary>
        /// ID dell'utente associato all'ordine.
        /// </summary>
        public int UserId { get; set; }

        public int AddressId { get; set; }
    }

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
        /// Quantità del prodotto.
        /// </summary>
        public int Quantity { get; set; }
    }
}
