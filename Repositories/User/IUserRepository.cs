using HR_System.DTOs.UserDto;

namespace HR_System.Repositories.User
{
    public interface IUserRepository
    {
        List<UserDto> GetAll();
        void Insert(UserDto NewUser);
        UserDto GetById(int id);
        void Update(UserDto UpdateUSer);
        void Delete(int id);
    }
}
