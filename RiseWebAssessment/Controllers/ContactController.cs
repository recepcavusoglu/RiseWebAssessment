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
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
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
        [HttpPost("AddContact")]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            if(contactService.GetContact(contact.Id) == null)
            {
                return Ok(contactService.AddContact(contact));
            }
            return BadRequest("Contact Already Exist");
        }
        [HttpPut("UpdateContact")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact request)
        {
            var contact = contactService.UpdateContact(request);
            if (contact == request) { return BadRequest("Error while updating"); }
            return Ok(contact);
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = contactService.GetContact(id);
            if (contact == null)
            {
                return BadRequest("Contact not found.");
            }
            contactService.DeleteContact(id);
            return Ok("Contact Deleted");
        }

        [HttpPut("DeactivateContact/{id}")]
        public async Task<ActionResult<Contact>> DeactivateContact(int id)
        {
            var contact = contactService.GetContact(id);
            if (contact == null)
            {
                return BadRequest("Contact not found.");
            }
            contactService.DeleteContact(id);
            return Ok("Contact Deleted");
        }

        [HttpGet("GetAllActiveContacts/{id}")]
        public async Task<ActionResult<List<Contact>>> GetAllActiveContacts()
        {
            return Ok(GetAllActiveContacts());
        }
    }
}
