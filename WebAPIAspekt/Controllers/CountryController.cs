using Microsoft.AspNetCore.Mvc;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;  
        }

        [Route("GetCountries")]
        [HttpGet]
        public List<Country> Get()
        {
            return _countryService.Get();
        }

        [Route("AddCountry")]
        [HttpPost]
        public int Create(AddCountryDto addCountryDto)
        {
            return _countryService.Create(addCountryDto);
        }

        [Route("UpdateCountry")]
        [HttpPost]
        public Country Update(UpdateCountryDto updateCountryDto)
        {
            return _countryService.Update(updateCountryDto);
        }

        [Route("DeleteCountry")]
        [HttpDelete]
        public void Delete(int companyId)
        {
            _countryService.Delete(companyId);
        }

    }
}
