namespace WebAPIAspekt.Models.Dtos
{
    public class UpdateContactDto
    {
        public int ContactId {  get; set; }
        public string? ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
