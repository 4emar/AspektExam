namespace WebAPIAspekt.Models.Dtos
{
    public class AddContactDto
    {
        public string? ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
