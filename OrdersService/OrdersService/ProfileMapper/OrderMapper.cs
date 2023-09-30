using AutoMapper;

using OrdersService.Model;
using OrdersService.Service.Order.Dto;

namespace OrdersService.ProfileMapper
{
    /// <summary>
    /// Mapper per la conversione tra oggetti Order e OrderDto.
    /// </summary>
    public class OrderMapper : Profile
    {
        /// <summary>
        /// Costruttore che definisce le mappe tra Order e OrderDto.
        /// </summary>
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Products, y => y.MapFrom(z => z.OrderProducts))
                .ReverseMap()
                ;

            CreateMap<OrderProducts, ProductDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ReverseMap()
                ;
        }
    }
}
