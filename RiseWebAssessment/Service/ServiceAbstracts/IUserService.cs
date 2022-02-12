using RiseWebAssessment.Model.DTO;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IUserService
    {
        public User GetUser(int id);
        public List<User> GetAllUsers();
        public User AddUser(User user);
        public User UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
