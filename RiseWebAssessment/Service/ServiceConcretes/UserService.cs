using AutoMapper;
using RiseWebAssessment.Model.DTO;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserService(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }



        public List<UserDto> GetAllUsers()
        {
            var users = _dataContext.Users.ToList();
            return _mapper.Map<List<UserDto>>(users);
        }
        public UserDto GetUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user != null)
            {                
                return _mapper.Map<UserDto>(_dataContext.Users.Find(id));                
            }
            return null;
        }
        public async Task AddUser(UserDto userDto)
        {
            var mappedUser = _mapper.Map<User>(userDto);
            mappedUser.LastModify = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            await _dataContext.Users.AddAsync(mappedUser);            
            _dataContext.SaveChanges();
        }
        public UserDto UpdateUser(UserDto request)
        {
            var user = _dataContext.Users.Find(request.Id);
            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Company = request.Company;
                user.LastModify = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                _dataContext.SaveChanges();
                return _mapper.Map<UserDto>(user);
            }
            return request;
        }        
        public void DeleteUser(int id)
        {
            _dataContext.Users.Remove(_dataContext.Users.Find(id));
            _dataContext.SaveChangesAsync();
        }
        public void ChangeUserStatus(int id)
        {
            var user = _dataContext.Users.Find(id);
            user.IsActive = !(user.IsActive);
            user.LastModify= DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }
        public async Task<List<UserDto>> GetAllActiveUsers()
        {
            var users = _dataContext.Users.Where(x => x.IsActive).ToList();
            return _mapper.Map<List<UserDto>>(users);
        }
        public bool UserExist(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public UserWithContactDto GetUserWithContact(int id)
        {
            var user = _dataContext.Users.Find(id);
            user.Contact = _dataContext.Contacts.Where(x => x.UserId == id).ToList();
            return _mapper.Map<UserWithContactDto>(user); ;
        }
    }
}
