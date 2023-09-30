namespace ApiService.Service.Order.Dto
{
    public class OrderDto
    {
        public string OrderName { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
