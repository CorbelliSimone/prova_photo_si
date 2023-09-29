using AutoMapper;
using ProductsService.Model;
using ProductsService.Service.Product.Dto;

namespace ProductsService.PropfileMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap()
                ; // Mappa Product a ProductDto
        }
    }
}
