using RiseWebAssessment.Model;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IContactService
    {
        public List<Contact> GetAllContacts();
        public Contact GetContact(int id);
        public Contact AddContact(Contact contact);
        public void DeleteContact(int id);
        public Contact UpdateContact(Contact contact);
        public void DeactivateContact(int id);
        public List<Contact> GetAllActiveContacts();
    }
}
