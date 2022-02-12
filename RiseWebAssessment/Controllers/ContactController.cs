using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Model;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet("GetContacts")]
        public async Task<ActionResult<List<User>>> GetAllContacts()
        {
            return Ok(contactService.GetAllContacts());
        }
        [HttpGet("GetContactById/{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = contactService.GetContact(id);
            if (contact == null)
            {
                return BadRequest("Contact Couldnt Found");
            }
            return Ok(contact);
        }
        // TODO : Check if contact already exist
        [HttpPost("AddContact")]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {            
            return Ok(contactService.AddContact(contact));
        }
    }
}
