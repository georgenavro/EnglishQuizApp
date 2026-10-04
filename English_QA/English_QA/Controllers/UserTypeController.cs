using English_QA.Interface;
using English_QA.Models.DatabaseModels;
using English_QA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : ControllerBase,IAllTypesControllers<Usertype>
    {
        public UserTypeRepo UsersTypeRepo;

        public UserTypeController(UserTypeRepo usersTypeRepo)
        {
            UsersTypeRepo = usersTypeRepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult> Add(Usertype entity)
        {
            try
            {
                var result = await UsersTypeRepo.Add(entity);
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
                var result = await UsersTypeRepo.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Get")]
        public async Task<ActionResult<List<Usertype>>> Get()
        {
            try
            {

                var result = await UsersTypeRepo.Get();

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
        public async Task<ActionResult> Update(Usertype entity)
        {
            try
            {
                var result = await UsersTypeRepo.Update(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
