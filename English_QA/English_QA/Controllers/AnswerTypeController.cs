using English_QA.Interface;
using English_QA.Models.DatabaseModels;
using English_QA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerTypeController : ControllerBase,IAllTypesControllers<AnswerTypes>
    {
        public AnswerTypeRepo AnswerTypeRepo;

        public AnswerTypeController(AnswerTypeRepo answerTypeRepo)
        {
            AnswerTypeRepo = answerTypeRepo;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult> Add(AnswerTypes entity)
        {
            try 
            {
                var result = await AnswerTypeRepo.Add(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var result = await AnswerTypeRepo.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
            
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Get")]
        public async Task<ActionResult<List<AnswerTypes>>> Get()
        {
            try
            {
                var result = await AnswerTypeRepo.Get();

                if(result == null)
                {
                    return BadRequest();
                }
                return result;
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(AnswerTypes entity)
        {
            try
            {
                var result = await AnswerTypeRepo.Update(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
