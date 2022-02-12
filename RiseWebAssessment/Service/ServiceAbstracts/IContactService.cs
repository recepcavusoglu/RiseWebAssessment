using RiseWebAssessment.Model;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IContactService
    {
        public List<Contact> GetAllContacts();
        public Contact GetContact(int id);
        public Contact AddContact(Contact contact);
    }
}
