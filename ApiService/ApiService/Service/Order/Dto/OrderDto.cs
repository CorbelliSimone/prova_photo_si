namespace ApiService.Service.Order.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string OrderName { get; set; }
        public List<ProductDto> Products { get; set; }
    }

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
