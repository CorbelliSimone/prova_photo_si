using AutoMapper.Configuration.Conventions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersService.Model
{
    /// <summary>
    /// Rappresenta un ordine nel sistema.
    /// </summary>
    [Table("order")]
    public class Order
    {
        /// <summary>
        /// Identificatore univoco dell'ordine.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Numero univoco dell'ordine.
        /// </summary>
        [Column("order_number"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        /// <summary>
        /// Nome dell'ordine.
        /// </summary>
        [Column("order_name"), Required]
        public string OrderName { get; set; }

        /// <summary>
        /// Identificatore dell'utente associato a questo ordine.
        /// </summary>
        [Column("user_id"), Required]
        public int UserId { get; set; }

        /// <summary>
        /// Prodotti associati a questo ordine.
        /// </summary>
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
