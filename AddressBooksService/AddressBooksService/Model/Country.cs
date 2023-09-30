using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBooksService.Model
{
    /// <summary>
    /// Rappresenta un paese nel sistema.
    /// </summary>
    [Table("country")]
    public class Country
    {
        /// <summary>
        /// Ottiene o imposta l'identificatore univoco del paese.
        /// </summary>
        [Column("id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome del paese.
        /// </summary>
        [Column("name"), Required]
        public string Name { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice alfa-3 del paese.
        /// </summary>
        [Column("alpha_3"), Required]
        public string Alpha3 { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice alfa-2 del paese.
        /// </summary>
        [Column("alpha_2"), Required]
        public string Alpha2 { get; set; }

        /// <summary>
        /// Ottiene o imposta l'insieme delle città associate a questo paese.
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}
