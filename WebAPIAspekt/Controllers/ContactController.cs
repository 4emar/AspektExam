using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAspekt.Interfaces;
using WebAPIAspekt.Models;
using WebAPIAspekt.Models.Dtos;
using WebAPIAspekt.Services;

namespace WebAPIAspekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("GetContacts")]
        [HttpGet]
        public List<Contact> Get()
        {
            return _contactService.Get();
        }

        [Route("CreateContact")]
        [HttpPost]
        public int Create(AddContactDto addContactDto)
        {
            return _contactService.Create(addContactDto);
        }

        [Route("UpdateContact")]
        [HttpPost]
        public Contact Update(UpdateContactDto updateContactDto)
        {
            return _contactService.Update(updateContactDto);
        }

        [Route("DeleteContact")]
        [HttpDelete]
        public void Delete(int id)
        {
            _contactService.Delete(id);
        }

        [Route("GetContactsWithCompanyAndCountry")]
        [HttpGet]
        public List<Contact> GetContactsWithCompanyAndCountry()
        {
            return _contactService.GetContactsWithCompanyAndCountry();
        }

        [Route("FilterContacts")]
        [HttpGet]
        public List<Contact> FilterContact(int countryId, int company)
        {
            return _contactService.FilterContact(countryId, company);
        }
    }
}
