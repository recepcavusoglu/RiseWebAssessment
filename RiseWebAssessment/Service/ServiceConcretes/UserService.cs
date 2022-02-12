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
            user.LastModify = DateTime.Now;
            _dataContext.SaveChanges();
            return user;
        }
        // TODO : Test This!!!
        public User UpdateUser(User request)
        {
            var user = _dataContext.Users.Find(request.Id);
            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Company = request.Company;
                user.LastModify = DateTime.Now;
                _dataContext.SaveChanges();
                return user;                
            }
            return request;
        }        
        public void DeleteUser(int id)
        {
            _dataContext.Users.Remove(_dataContext.Users.Find(id));
            _dataContext.SaveChangesAsync();
        }
        public void DeactivateUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            user.IsActive= false;
            user.LastModify=DateTime.Now;
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }
        public List<User> GetAllActiveUsers()
        {
            var users = _dataContext.Users.Where(x => x.IsActive).ToList();
            return users;
        }
    }
}
