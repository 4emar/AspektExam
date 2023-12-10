using Microsoft.AspNetCore.Mvc;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models.Dtos;
using WebAPIAspekt.Models;

namespace WebAPIAspekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("GetCompanies")]
        [HttpGet]
        public List<Company> Get()
        {
            return _companyService.Get();
        }

        [Route("AddCompany")]
        [HttpPost]
        public int Create([FromBody] AddCompanyDto addCompanyDto)
        {
            return _companyService.Create(addCompanyDto);
        }

        [Route("UpdateCompany")]
        [HttpPost]
        public Company Update([FromBody] UpdateCompanyDto updateCompanyDto)
        {
            return _companyService.Update(updateCompanyDto);
        }

        [Route("DeleteCompany")]
        [HttpDelete]
        public void Delete(int companyId)
        {
            _companyService.Delete(companyId);
        }
        
    }
}
