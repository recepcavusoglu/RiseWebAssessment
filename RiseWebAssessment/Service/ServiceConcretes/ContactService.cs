using AutoMapper;
using RiseWebAssessment.Model;
using RiseWebAssessment.Model.DTO;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ContactService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task AddContact(ContactDto contactDto)
        {
            var mappedUser = _mapper.Map<Contact>(contactDto);
            mappedUser.LastModify = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            await _dataContext.Contacts.AddAsync(mappedUser);
            _dataContext.SaveChanges();
        }
        public ContactDto GetContact(int id)
        {
            var contact = _dataContext.Contacts.Find(id);
            if (contact != null)
            {
                return _mapper.Map<ContactDto>(_dataContext.Contacts.Find(id));
            }
            return null;
        }

        public List<ContactDto> GetAllContacts()
        {
            var contacts = _dataContext.Contacts.ToList();
            return _mapper.Map<List<ContactDto>>(contacts);
        }
        // TODO: Can this be beter?
        public ContactDto UpdateContact(ContactDto request)
        {
            var contact = _dataContext.Contacts.Find(request.Id);
            if (contact != null)
            {
                contact.InfoContent = request.InfoContent;
                contact.LastModify = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                _dataContext.Contacts.Update(contact);
                _dataContext.SaveChanges();
                return _mapper.Map<ContactDto>(contact);
            }
            return request;
        }
        public void DeleteContact(int id)
        {
            _dataContext.Contacts.Remove(_dataContext.Contacts.Find(id));
            _dataContext.SaveChangesAsync();
        }
        public void ChangeContactStatus(int id) 
        {
            var contact = _dataContext.Contacts.Find(id);
            contact.IsActive = !(contact.IsActive);
            contact.LastModify = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            _dataContext.Contacts.Update(contact);
            _dataContext.SaveChanges();
        }
        public async Task<List<ContactDto>> GetAllActiveContacts()
        {
            var contacts = _dataContext.Contacts.Where(x => x.IsActive).ToList();
            return _mapper.Map<List<ContactDto>>(contacts);
        }
        public bool ContactExist(int id)
        {
            var contact = _dataContext.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }
            return true;
        }
        public List<ContactDto> GetContactWithUserId(int id)
        {
            var contact = _dataContext.Contacts.Where(x => x.UserId == id);
            var contactDto = _mapper.Map<List<ContactDto>>(contact);
            return contactDto;
        }
    }
}
