using RiseWebAssessment.Model.DTO;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IUserService
    {
        public UserDto GetUser(int id);
        public List<UserDto> GetAllUsers();
        public Task AddUser(UserDto user);
        public UserDto UpdateUser(UserDto user);
        public void DeleteUser(int id);
        public void DeactivateUser(int id);
        public Task<List<UserDto>> GetAllActiveUsers();
    }
}
