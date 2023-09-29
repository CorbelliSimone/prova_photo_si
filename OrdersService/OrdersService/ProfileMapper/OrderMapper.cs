using AutoMapper;

using OrdersService.Model;
using OrdersService.Service.Order.Dto;

namespace OrdersService.ProfileMapper
{
    public class OrderMapper : Profile
    {
        public OrderMapper() {
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
