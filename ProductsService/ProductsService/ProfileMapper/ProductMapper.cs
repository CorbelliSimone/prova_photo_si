using AutoMapper;

using ProductsService.Model;
using ProductsService.Service.Product.Dto;

namespace ProductsService.ProfileMapper
{
    /// <summary>
    /// Classe per la configurazione della mappatura tra Product e ProductDto.
    /// </summary>
    public class ProductMapper : Profile
    {
        /// <summary>
        /// Crea un nuovo oggetto ProductMapper e configura la mappatura tra Product e ProductDto.
        /// </summary>
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}
