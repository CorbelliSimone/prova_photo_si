using AutoMapper.Configuration.Conventions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersService.Model
{
    [Table("order")]
    public class Order
    {
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("order_number"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        [Column("order_name"), Required]
        public string OrderName { get; set; }

        [Column("user_id"), Required]
        public int UserId { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
