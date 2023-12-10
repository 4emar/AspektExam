using WebAPIAspekt.Data;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Create(AddContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.ContactName = contactDto.ContactName;
            if (_context.Companies.Find(contactDto.CompanyId) != null)
            {
                contact.CompanyId = contactDto.CompanyId;
            }
            else
            {
                throw new InvalidOperationException("Invalid CompanyId. Company not found.");
            }
            if (_context.Countries.Find(contactDto.CountryId) != null)
            {
                contact.CountryId = contactDto.CountryId;
            }
            else
            {
                throw new InvalidOperationException("Invalid CountryId. Country not found.");
            }
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact.ContactId;
        }

        public Contact Update(UpdateContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = contactDto.ContactId;
            contact.ContactName = contactDto.ContactName;
            if (_context.Companies.Find(contactDto.CompanyId) != null)
            {
                contact.CompanyId = contactDto.CompanyId;
            }
            else
            {
                throw new InvalidOperationException($"Invalid CompanyId ({contactDto.ContactId}). Company not found.");
            }
            if (_context.Countries.Find(contactDto.CountryId) != null)
            {
                contact.CountryId = contactDto.CountryId;
            }
            else
            {
                throw new InvalidOperationException($"Invalid CountryId ({contactDto.CountryId}). Country not found.");
            }
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return contact;
        }

        public void Delete(int contactId)
        {
            var contact1 = _context.Contacts.Find(contactId);

            if (contact1 != null)
            {
                _context.Contacts.Remove(contact1);
                _context.SaveChanges();
            }
            else { throw new InvalidOperationException($"Invalid ContactId ({contactId}). Contact not found."); }
        }

        public List<Contact> Get()
        {
            return _context.Contacts.ToList();
        }

        public List<Contact> GetContactsWithCompanyAndCountry()
        {
            return _context.Contacts
                .Where(c => c.CompanyId != 0 && c.CountryId != 0)
                .ToList();
        }

        public List<Contact> FilterContact(int countryId, int companyId)
        {
            if (countryId == 0 && companyId !=  0)
            {
                return _context.Contacts
                    .Where(c => c.CompanyId == companyId)
                    .ToList();
            }
            else if (countryId != 0 && companyId == 0)
            {
                return _context.Contacts
                    .Where(c => c.CountryId == countryId)
                    .ToList();
            }
            else
            {
                return _context.Contacts
                   .Where(c => c.CompanyId == companyId && c.CountryId == countryId)
                   .ToList();
            }

        }

    }
}
