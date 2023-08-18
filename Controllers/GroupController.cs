using HR_System.Repositories.Group;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepo)
        {
            this._groupRepository=groupRepo;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
           var groups= _groupRepository.GetAll();
            if(groups != null)
            {
                return Ok(groups);
            }
            return BadRequest();

        }
    }
}
