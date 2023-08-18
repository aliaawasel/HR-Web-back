using HR_System.DTOs.UserDto;
using HR_System.Models;
using System.ComponentModel.DataAnnotations;

namespace HR_System.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly HREntity hREntity;
        public UserRepository(HREntity hREntity) => this.hREntity = hREntity;

        public List<UserDto> GetAll()
        {
            var users = hREntity.Users.Where(u => u.IsDeleted == false).ToList();
            var UserSDto = users.Select(u => new UserDto
            {
                ID = u.ID,
                Username = u.Username,
                FullName = u.FullName,
                Password = u.Password,
                Email = u.Email,
                GroupID = u.GroupID
            }).ToList();
            return (UserSDto);
        }
        //public UserDto GetByUsername(string username)
        //{
        //    var user = hREntity.Users.FirstOrDefault(u => u.Username == username && u.IsDeleted != true);
        //    UserDto userDto = new UserDto();

        //    userDto.Username = user.Username;
        //    userDto.FullName = user.FullName;
        //    userDto.Password = user.Password;
        //    userDto.Email = user.Email;
        //    userDto.GroupID = user.GroupID;
        //    return (userDto);
        //}
        public UserDto GetById(int id)
        {
            var user = hREntity.Users.FirstOrDefault(u => u.ID == id && u.IsDeleted != true);
            UserDto userDto = new UserDto();
            userDto.ID = id;
            userDto.Username = user.Username;
            userDto.FullName = user.FullName;
            userDto.Password = user.Password;
            userDto.Email = user.Email;
            userDto.GroupID = user.GroupID;
            return (userDto);
        }
        public void Insert(UserDto NewUserDto)
        {
            var newUser = new Models.User
            {
                Username = NewUserDto.Username,
                FullName = NewUserDto.FullName,
                Password = NewUserDto.Password,
                Email = NewUserDto.Email,
                GroupID = NewUserDto.GroupID
            };
            hREntity.Users.Add(newUser);
            hREntity.SaveChanges();
        }
        public void Update(UserDto UpdateUserDto)
        {

            var newUser = new Models.User
            {
                ID = UpdateUserDto.ID,
                Username = UpdateUserDto.Username,
                FullName = UpdateUserDto.FullName,
                Password = UpdateUserDto.Password,
                Email = UpdateUserDto.Email,
                GroupID = UpdateUserDto.GroupID
            };
            hREntity.Update(newUser);
            hREntity.SaveChanges();
        }
        public void Delete(int id)
        {
            var old = hREntity.Users.FirstOrDefault(u => u.ID == id && u.IsDeleted != true);
            if (old != null)
            {
                old.IsDeleted = true;
                hREntity.SaveChanges();
            }
        }

    }
}
