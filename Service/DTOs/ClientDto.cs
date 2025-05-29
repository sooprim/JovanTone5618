using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Service.DTOs
{
    public class ClientDto
    {
        [SwaggerSchema(ReadOnly = true)]
        [DefaultValue(0)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DefaultValue("New Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        [DefaultValue("New Surname")]
        public string LastName { get; set; }

        [Required]
        [DefaultValue("2004-04-28")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(400)]
        [DefaultValue("123 Main St")]
        public string Address { get; set; }

        [Required]
        [DefaultValue("MC123456")]
        public string MembershipCardNumber { get; set; }

        [Required]
        [DefaultValue("2024-12-31")]
        public DateTime MembershipCardValidityDate { get; set; }

        [DefaultValue("2024-05-25")]
        public DateTime? LoanDate { get; set; }

        [DefaultValue("2024-06-25")]
        public DateTime? ReturnDate { get; set; }

        [DefaultValue(1)]
        public int? BookId { get; set; }
    }
} 