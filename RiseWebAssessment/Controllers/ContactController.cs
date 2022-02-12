using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Model;

namespace RiseWebAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ContactController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet("GetContacts")]
        public async Task<ActionResult<List<User>>> GetContacts()
        {
            return Ok(await this.dataContext.Contacts.ToListAsync());
        }
        [HttpPost("AddContact")]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            this.dataContext.Contacts.AddAsync(contact);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Contacts.ToListAsync());
        }
    }
}
