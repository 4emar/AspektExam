using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Interfaces
{
    public interface ICompanyService
    {
        List<Company> Get();
        int Create(AddCompanyDto addCompanyDto);
        Company Update(UpdateCompanyDto updateCompanyDto);
        void Delete(int  id);
    }
}
