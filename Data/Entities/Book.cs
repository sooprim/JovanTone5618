using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IBAN { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Author { get; set; }

        [Required]
        [StringLength(200)]
        public string Publisher { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
} 