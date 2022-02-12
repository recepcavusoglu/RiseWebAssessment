using RiseWebAssessment.Model;
using RiseWebAssessment.Model.DTO;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IContactService
    {
        public List<ContactDto> GetAllContacts();
        public ContactDto GetContact(int id);
        public Task AddContact(ContactDto contactDto);
        public void DeleteContact(int id);
        public ContactDto UpdateContact(ContactDto contact);
        public void DeactivateContact(int id);
        public Task<List<ContactDto>> GetAllActiveContacts();
    }
}
