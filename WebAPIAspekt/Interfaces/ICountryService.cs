using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Interfaces
{
    public interface ICountryService
    {
        int Create(AddCountryDto countryDto);
        Country Update(UpdateCountryDto countryDto);
        void Delete(int id);
        List<Country> Get();
    }
}
