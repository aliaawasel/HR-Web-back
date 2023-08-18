using HR_System.DTOs.EmployeeDto;
using HR_System.DTOs.UserDto;
using HR_System.Models;
using HR_System.Repositories.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository UserRepo) => this._userRepository = UserRepo;

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var Users = _userRepository.GetAll();

            return Users.IsNullOrEmpty() ? NotFound() : Ok(Users);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user is null ? NotFound() : Ok(user);
        }


        [HttpPost("insert")]
        public IActionResult Insert(UserDto newUser)
        {
            if (ModelState.IsValid == true)
            {
                _userRepository.Insert(newUser);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UserDto updateUser)
        {
            if (ModelState.IsValid == true)
            {
                _userRepository.Update(updateUser);
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
