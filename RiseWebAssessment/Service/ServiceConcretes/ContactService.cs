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
            _dataContext.Contacts.Update(contact);
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
        public Contact UpdateContact(Contact request)
        {
            var contact = _dataContext.Contacts.Find(request.Id);
            if (contact != null)
            {
                contact.InfoContent = request.InfoContent;
                contact.LastModify = DateTime.Now;
                _dataContext.Contacts.Update(contact);
                _dataContext.SaveChanges();
                return contact;
            }
            return request;
        }
        public void DeleteContact(int id)
        {
            _dataContext.Contacts.Remove(_dataContext.Contacts.Find(id));
            _dataContext.SaveChangesAsync();
        }
        public void DeactivateContact(int id) 
        {
            var contact = _dataContext.Contacts.Find(id);
            contact.IsActive = !contact.IsActive;
            contact.LastModify = DateTime.Now;
            _dataContext.Contacts.Update(contact);
            _dataContext.SaveChanges();
        }
        public List<Contact> GetAllActiveContacts()
        {
            return  _dataContext.Contacts.Where(x => x.IsActive).ToList();
        }
    }
}
