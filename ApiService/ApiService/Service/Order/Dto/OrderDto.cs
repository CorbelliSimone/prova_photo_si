namespace ApiService.Service.Order.Dto
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public string OrderName { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
