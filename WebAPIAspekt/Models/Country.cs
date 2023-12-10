using System.ComponentModel.DataAnnotations;

namespace WebAPIAspekt.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string? CountryName { get; set; }

    }
}
