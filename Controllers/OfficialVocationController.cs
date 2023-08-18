using HR_System.DTOs.OfficialvocationDto;
using HR_System.Repositories.Official_Vocations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialVocationController : ControllerBase
    {
        private readonly IOfficialVocationsRepository VocationsRepo;
        public OfficialVocationController(IOfficialVocationsRepository VocationsRepository)
        {
            this.VocationsRepo = VocationsRepository;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var vocations = VocationsRepo.GetAll();
            if (vocations != null)
            {
                return Ok(vocations);
            }
            return BadRequest();
        }
        [HttpGet("ById/{id}")]
        public IActionResult GetbyId(int id)
        {
            var vocation = VocationsRepo.GetVocationById(id);
            if (vocation != null)
            {
                return Ok(vocation);
            }
            return BadRequest();
        }

        [HttpPost("Insert")]
        public IActionResult Insert(OfficialVocationDto vocationDto)
        {
            var res=VocationsRepo.Insert(vocationDto);
            if (res == 1)
            {
                if (ModelState.IsValid == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
            {
                if (ModelState.IsValid == true)
                {
                    var sentence = new { Message = "AddedBefore" };

                    return Ok(sentence);
                }
                return BadRequest();
            }

        }
        [HttpPut("Update")]
        public IActionResult Update(OfficialVocationDto vocationDto)
        {
            VocationsRepo.Update(vocationDto);
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                VocationsRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
}
