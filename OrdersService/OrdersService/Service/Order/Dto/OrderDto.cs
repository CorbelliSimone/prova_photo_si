namespace OrdersService.Service.Order.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string OrderName { get; set; }
        public List<ProductDto> Products { get; set; }
        public int UserId { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
