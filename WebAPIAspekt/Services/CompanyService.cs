using WebAPIAspekt.Data;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public List<Company> Get()
        {
            return _context.Companies.ToList();
        }

        public int Create(AddCompanyDto addCompanyDto)
        {
            Company company = new Company();
            company.CompanyName = addCompanyDto.CompanyName;
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company.CompanyId;
        }

        public Company Update(UpdateCompanyDto updateCompanyDto)
        {
            Company company = new Company();
            company.CompanyId = updateCompanyDto.CompanyId;
            company.CompanyName = updateCompanyDto.CompanyName;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }

        public void Delete(int companyId)
        {
            var company1 = _context.Companies.Find(companyId);
            if (company1 != null)
            {
                _context.Companies.Remove(company1);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidDataException($"Invalid CompanyId ({companyId}). Company not found.");
            }
        }
    }
}
