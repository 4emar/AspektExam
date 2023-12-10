using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;

namespace WebAPIAspekt.Interfaces
{
    public interface IContactService
    {
        int Create(AddContactDto addContactDto);
        Contact Update(UpdateContactDto updateContactDto);
        void Delete(int id);
        List<Contact> Get();
        List<Contact> GetContactsWithCompanyAndCountry();
        List<Contact> FilterContact(int countryId, int company);
    }
}
