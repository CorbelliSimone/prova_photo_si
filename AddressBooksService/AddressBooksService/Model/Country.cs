using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBooksService.Model
{
    [Table("country")]
    public class Country
    {
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("alpha_3"), Required]
        public string Alpha3 { get; set; }

        [Column("alpha_2"), Required]
        public string Alpha2 { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
