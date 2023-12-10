using WebAPIAspekt.Data;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models.Dtos;
using WebAPIAspekt.Models;

namespace WebAPIAspekt.Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;

        public CountryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public int Create(AddCountryDto countryDto)
        {
            Country country = new Country();
            country.CountryName = countryDto.CountryName;
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country.CountryId;
        }

        public Country Update(UpdateCountryDto countryDto)
        {
            Country country = new Country();
            country.CountryId = countryDto.CountryId;
            country.CountryName = countryDto.CountryName;
            _context.Countries.Update(country);
            _context.SaveChanges();
            return country;
        }

        public void Delete(int countryId)
        {
            var country1 = _context.Countries.Find(countryId);
            if (country1 != null)
            {
                _context.Countries.Remove(country1);
                _context.SaveChanges();
            }
            else { throw new InvalidDataException($"Invalid CountryId ({countryId}). Country not found.");  }
        }

        public List<Country> Get()
        {
            return _context.Countries.ToList();
        }

    }
}
