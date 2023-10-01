using ApiService.Service.AddressBook.Dto;
using ApiService.Service.Product.Dto;

namespace ApiService.Service.Order.Dto
{
    /// <summary>
    /// Data transfer object completo per un ordine mappato.
    /// </summary>
    public class OrderMapperCompleteDto
    {
        /// <summary>
        /// ID dell'ordine.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID dell'utente associato all'ordine.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome dell'ordine.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Indirizzo completo associato all'ordine.
        /// </summary>
        public AddressCompleteDto Address { get; set; }

        /// <summary>
        /// Elenco dei prodotti nell'ordine con informazioni complete.
        /// </summary>
        public List<ProductOrdersDto> Products { get; set; }
    }

    /// <summary>
    /// Data transfer object per un prodotto nell'ordine con informazioni complete.
    /// </summary>
    public class ProductOrdersDto : ProductCompleteDto
    {
        /// <summary>
        /// Quantità del prodotto.
        /// </summary>
        public int Quantity { get; set; }
    }
}
