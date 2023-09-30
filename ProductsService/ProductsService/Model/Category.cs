using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsService.Model
{
    /// <summary>
    /// Rappresenta una categoria di prodotti.
    /// </summary>
    [Table("category")]
    public class Category
    {
        /// <summary>
        /// ID della categoria.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nome della categoria.
        /// </summary>
        [Column("name"), Required]
        public string Name { get; set; }

        /// <summary>
        /// Prodotti associati a questa categoria.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
