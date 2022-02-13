using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Model;
using RiseWebAssessment.Model.DTO;
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
        public async Task<ActionResult<List<ContactDto>>> GetAllContacts()
        {
            return Ok(contactService.GetAllContacts());
        }
        [HttpGet("GetContactById/{id}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            if (contactService.ContactExist(id))
            {
                return Ok(contactService.GetContact(id));
                
            }
            return BadRequest("Contact Couldnt Found");
        }
        [HttpPost("AddContact")]
        public async Task<ActionResult<List<ContactDto>>> AddContact(ContactDto contactDto)
        {
            if(contactService.ContactExist(contactDto.Id))
            {
                return BadRequest("Contact Already Exist");
            }
            contactService.AddContact(contactDto);
            return Ok("Contact Added");
        }
        [HttpPut("UpdateContact")]
        public async Task<ActionResult<List<ContactDto>>> UpdateContact(ContactDto request)
        {
            var contact = contactService.UpdateContact(request);
            if (contact == null) { return BadRequest("Error couldnt found"); }
            return Ok(contact);
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<ActionResult<ContactDto>> DeleteContact(int id)
        {
            if (contactService.ContactExist(id))
            {
                return BadRequest("Contact not found.");
            }
            contactService.DeleteContact(id);
            return Ok("Contact Deleted");
        }

        [HttpPut("DeactivateContact/{id}")]
        public async Task<ActionResult<ContactDto>> ChangeContactStatus(int id)
        {
            if (contactService.ContactExist(id))
            {
                contactService.ChangeContactStatus(id);
                return Ok("Contact Deactivated");
            }
            return BadRequest("Contact not found.");
        }

        [HttpGet("GetAllActiveContacts")]
        public async Task<ActionResult<List<ContactDto>>> GetAllActiveContacts()
        {
            return Ok(GetAllActiveContacts());
        }
        [HttpGet("ContactExist/{id}")]
        public async Task<ActionResult> ContactExist(int id)
        {
            var exist = contactService.ContactExist(id);
            if (exist)
            {
                return Ok("Contact exist");
            }
            else
            {
                return Ok("Contact couldnt found");
            }
        }
        [HttpGet("GetContactWithUserId/{id}")]
        public async Task<ActionResult<List<ContactDto>>> GetContactWithUserId(int id)
        {
           return Ok(contactService.GetContactWithUserId(id));
        }
    }
}
