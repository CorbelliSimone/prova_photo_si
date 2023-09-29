using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBooksService.Model
{
    [Table("city")]
    public class City
    {
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("cadastral_code"), Required]
        public string CadastralCode { get; set; }

        [Column("country_id"), Required]
        public int CountryId { get; set; }

        public virtual ICollection<AddressBook> AddressBooks { get; set; }
        public virtual Country Country { get; set; }
    }
}
