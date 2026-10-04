using English_QA.Interface;
using English_QA.Models.DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionCategoryController : ControllerBase,IAllTypesControllers<QuestionCategory>
    {
        public QuestionCategoryRepo questionCategoryRepo;

        public QuestionCategoryController(QuestionCategoryRepo questionCategoryRepo)
        {
            this.questionCategoryRepo = questionCategoryRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult> Add(QuestionCategory entity)
        {
            try
            {
                var result = await questionCategoryRepo.Add(entity);
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
                var result = await questionCategoryRepo.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Get")]
        public async Task<ActionResult<List<QuestionCategory>>> Get()
        {
            try
            {
                var result = await questionCategoryRepo.Get();

                if (result == null)
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
        public async Task<ActionResult> Update(QuestionCategory entity)
        {
            try
            {
                var result = await questionCategoryRepo.Update(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

     
    }
}
