using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsService.Model
{
    /// <summary>
    /// Rappresenta un prodotto.
    /// </summary>
    [Table("product")]
    public class Product
    {
        /// <summary>
        /// ID del prodotto.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ID della categoria a cui il prodotto appartiene.
        /// </summary>
        [Column("category_id"), Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome del prodotto.
        /// </summary>
        [Column("name"), Required]
        public string Name { get; set; }

        /// <summary>
        /// Descrizione del prodotto.
        /// </summary>
        [Column("description"), Required]
        public string Description { get; set; }

        /// <summary>
        /// Categoria a cui il prodotto appartiene.
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
