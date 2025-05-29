using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Service.DTOs
{
    public class BookDto
    {
        [SwaggerSchema(ReadOnly = true)]
        [DefaultValue(0)]
        public int Id { get; set; }

        [Required]
        [DefaultValue("978-1-4088-5589-8")]
        public string IBAN { get; set; }

        [Required]
        [DefaultValue("The Alchemist")]
        public string Name { get; set; }

        [Required]
        [DefaultValue("Paulo Coelho")]
        public string Author { get; set; }

        [Required]
        [DefaultValue("HarperOne")]
        public string Publisher { get; set; }

        [Required]
        [DefaultValue(1988)]
        public int Year { get; set; }

        [Required]
        [DefaultValue(6)]
        public int NumberOfCopies { get; set; }
    }
} 