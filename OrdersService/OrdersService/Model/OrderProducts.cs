using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersService.Model
{
    /// <summary>
    /// Rappresenta un prodotto all'interno di un ordine nel sistema.
    /// </summary>
    [Table("order_products")]
    public class OrderProducts
    {
        /// <summary>
        /// Identificatore univoco del prodotto in un ordine.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Identificatore del prodotto associato a questo record.
        /// </summary>
        [Column("product_id"), Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Identificatore dell'ordine a cui questo record è associato.
        /// </summary>
        [Column("order_id"), Required]
        public int OrderId { get; set; }

        /// <summary>
        /// Quantità del prodotto in questo record.
        /// </summary>
        [Column("quantity"), Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Ordine a cui questo record è associato.
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
