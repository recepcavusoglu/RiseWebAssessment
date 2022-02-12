using RiseWebAssessment.Model;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;

        public ContactService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Contact AddContact(Contact contact)
        {
            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }
        public Contact GetContact(int id)
        {
            var contact = _dataContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                return _dataContext.Contacts.Find(id);
            }
            return null;
        }

        public List<Contact> GetAllContacts()
        {
            return _dataContext.Contacts.ToList();
        }
    }
}
