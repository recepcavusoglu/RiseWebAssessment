using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        public List<User> GetAllUsers()
        {
            return _dataContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            var user = _dataContext.Users.FindAsync(id);
            if (user != null)
            {
                return _dataContext.Users.Find(id);                
            }
            return null;
        }
        // TODO : Check user if already exist
        public User AddUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }
        public User UpdateUser(User request)
        {
            var user = _dataContext.Users.Find(request.Id);
            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Company = request.Company;
                _dataContext.SaveChanges();
                return user;                
            }
            return request;
        }
        // TODO : fix this after ResponseStatus
        public void DeleteUser(User deletionUser)
        {
            _dataContext.Users.Remove(deletionUser);
            _dataContext.SaveChangesAsync();
        }

    }
}
