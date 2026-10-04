using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTestController : ControllerBase, IAllTypesControllers<UserTest>
    {
        public UserTestRepo userTestRepo;
        public UserTestController(UserTestRepo userTestRepo) 
        {
            this.userTestRepo = userTestRepo;
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult> Add(UserTest entity)
        {
            try
            {
                var result = await userTestRepo.Add(entity);

                return Created("", result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody]long id)
        {
            try
            {
                var result = await userTestRepo.Delete(id);

                if (result != true)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Get")]
        public async Task<ActionResult<List<UserTest>>> Get()
        {
            //var tests = await userTestRepo.Get();
            return Ok();
        }

        [Authorize]
        [HttpPost("GetPreviousUserTests")]
        public async Task<ActionResult<List<GetPreviousUserTestDTO>>> GetUserTests([FromBody]long userID)
        {
            try
            {
                var result = await userTestRepo.GetPreviousUserTests(userID);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [Authorize]
        [HttpPost("GetUserTestSelection")]
        public async Task<ActionResult<List<UserGeneratedTestDTO>>> GetUserTestSelection(GetUserTestSelectionBody request)
        {
            try
            {
                var result = await userTestRepo.GetUserTestSelection(request);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(UserTest entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    return BadRequest();
                }
                var result = await userTestRepo.Update(entity);

                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("GenerateTest")]
        public async Task<ActionResult> GenerateTest(QA_GenerationTestBody request)
        {
            try
            {
                var results = await userTestRepo.GenerateTest(request);
                

                if (results == null)
                {
                    return BadRequest();
                }

                return Ok(results);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Pagination")]
        public async Task<ActionResult<List<QA_PaginationDTO>>?> pagination_userTest([FromQuery] PaginationFilter filter, UserTest_PaginationBody body)
        {
            var route = Request.Path.Value ?? String.Empty;
            var result = await userTestRepo.pagination(filter, route, body);

            if (result != null)
            {
                return Ok(result);
            }

            return null;
        }

    }
}
