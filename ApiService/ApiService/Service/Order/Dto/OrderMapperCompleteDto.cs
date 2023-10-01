using ApiService.Service.AddressBook.Dto;
using ApiService.Service.Product.Dto;

namespace ApiService.Service.Order.Dto
{
    public class OrderMapperCompleteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderName { get; set; }
        public AddressCompleteDto Address { get; set; }
        public List<ProductOrdersDto> Products { get; set; }
    }

    public class ProductOrdersDto : ProductCompleteDto
    {
        /// <summary>
        /// Quantità del prodotto.
        /// </summary>
        public int Quantity { get; set; }
    }
}
