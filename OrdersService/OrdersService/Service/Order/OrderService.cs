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

        public async Task<List<OrderDto>> GetAsync()
        {
            var orders = await _orderRepository.GetAllAndInclude();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var order = await _orderRepository.GetAndInclude(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> AddAsync(OrderDto orderDto)
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

            var inserted = await _orderRepository.AddAsync(new Model.Order()
            {
                OrderProducts = orderProducts,
                UserId = orderDto.UserId,
                OrderName = orderDto.OrderName
            });

            return _mapper.Map<OrderDto>(inserted);
        }
    }
}
