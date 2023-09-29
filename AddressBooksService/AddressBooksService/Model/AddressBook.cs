using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBooksService.Model
{
    [Table("address_book")]
    public class AddressBook
    {
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("street_name"), Required]
        public string StreetName { get; set; }

        [Column("cap"), Required]
        public string Cap { get; set; }

        [Column("street_number"), Required]
        public string StreetNumber { get; set; }

        [Column("city_id"), Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
