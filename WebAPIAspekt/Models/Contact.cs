using System.ComponentModel.DataAnnotations;

namespace WebAPIAspekt.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public string? ContactName { get; set; }

        public int CompanyId { get; set; }

        public int CountryId {  get; set; }

    }
}
