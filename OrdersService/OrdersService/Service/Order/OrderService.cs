using AutoMapper;

using OrdersService.Repository.Order;
using OrdersService.Service.Order.Dto;
using OrdersService.Service.Order.Exceptionz;

namespace OrdersService.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService
        (
            IOrderRepository orderRepository,
            IMapper mapper
        )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var orderToDelete = await _orderRepository.GetAsync(id);
            if (orderToDelete == null)
            {
                throw new OrderException($"Nessun ordine con id {id} trovato");
            }

            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<Model.Order>> GetAsync()
        {
            var orders = await _orderRepository.GetAsync();
            return _mapper.Map<List<Model.Order>>(orders);
        }

        public async Task<Model.Order> GetAsync(int id)
        {
            var order = await _orderRepository.GetAsync(id);
            return _mapper.Map<Model.Order>(order);
        }

        public async Task<Model.Order> AddAsync(OrderDto orderDto)
        {
            var orderProducts = new List<Model.OrderProducts>();
            orderDto.Products.ForEach(product =>
            {
                orderProducts.Add(new Model.OrderProducts()
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity
                });
            });

            var lastOrder = await _orderRepository.LastOrDefaultAsync();
            var newOrderNumber = lastOrder == null ? 1 : lastOrder.OrderNumber + 1;

            return await _orderRepository.AddAsync(new Model.Order()
            {
                OrderProducts = orderProducts,
                UserId = orderDto.UserId,
                OrderName = orderDto.OrderName,
                OrderNumber = newOrderNumber
            });
        }
    }
}
