using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(400)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string MembershipCardNumber { get; set; }

        [Required]
        public DateTime MembershipCardValidityDate { get; set; }

        public DateTime? LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
} 