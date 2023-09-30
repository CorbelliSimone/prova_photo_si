using AutoMapper;

using OrdersService.Repository.Order;
using OrdersService.Service.Order.Dto;
using OrdersService.Service.Order.Exceptionz;

namespace OrdersService.Service.Order
{
    /// <summary>
    /// Implementazione del servizio per la gestione degli ordini.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una nuova istanza di OrderService.
        /// </summary>
        /// <param name="orderRepository">Il repository degli ordini.</param>
        /// <param name="mapper">L'oggetto Mapper per la conversione degli oggetti.</param>
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Elimina un ordine in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID dell'ordine da eliminare.</param>
        /// <returns>Task che rappresenta l'operazione asincrona di eliminazione.</returns>
        public async Task DeleteAsync(int id)
        {
            var orderToDelete = await _orderRepository.GetAsync(id);
            if (orderToDelete == null)
            {
                throw new OrderException($"Nessun ordine con id {id} trovato");
            }

            await _orderRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Ottiene tutti gli ordini presenti.
        /// </summary>
        /// <returns>Task che restituisce una lista di oggetti OrderDto rappresentanti gli ordini.</returns>
        public async Task<List<OrderDto>> GetAsync()
        {
            var orders = await _orderRepository.GetAllAndInclude();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        /// <summary>
        /// Ottiene un ordine in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID dell'ordine da ottenere.</param>
        /// <returns>Task che restituisce l'oggetto OrderDto corrispondente all'ID specificato.</returns>
        public async Task<OrderDto> GetAsync(int id)
        {
            var order = await _orderRepository.GetAndInclude(id);
            return _mapper.Map<OrderDto>(order);
        }

        /// <summary>
        /// Aggiunge un nuovo ordine.
        /// </summary>
        /// <param name="orderDto">Oggetto OrderDto che rappresenta l'ordine da aggiungere.</param>
        /// <returns>Task che restituisce l'oggetto OrderDto aggiunto.</returns>
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
                OrderName = orderDto.OrderName,
                AddressId = orderDto.AddressId
            });

            return _mapper.Map<OrderDto>(inserted);
        }

        public async Task<List<OrderDto>> GetByProductIdAsync(int productId)
        {
            var foundedOrders = await _orderRepository.GetByProductIdAsync(productId);
            return _mapper.Map<List<OrderDto>>(foundedOrders);
        }

        public async Task<List<OrderDto>> GetByAddressIdAsync(int addressId)
        {
            var foundedOrders = await _orderRepository.GetByAddressIdAsync(addressId);
            return _mapper.Map<List<OrderDto>>(foundedOrders);
        }
    }
}
