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
    public class UsersController : ControllerBase
    {
        public UsersRepo usersRepo { get; set; }
        public UsersController(UsersRepo usersrepo)
        {
            usersRepo = usersrepo;
        }
        [HttpPost("Add")]
        
        public async Task<ActionResult<Users>> Add(Users entity)
        {
            try
            {
                var result = await usersRepo.Create(entity);
                if(result == null)
                {
                    return NotFound();
                }
                else if(result.UserTypeID == 3)
                {
                    return BadRequest();    
                }

                    return Ok(result);
            }
            catch
            {
                return BadRequest();
                
            }

        }
        [Authorize]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var result = await usersRepo.Delete(id);
                if(result == false)
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
        [Authorize]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(Users entity)
        {
            try
            {
                var result = await usersRepo.Edit(entity);
                if(result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Get")]
        public async Task<ActionResult<List<Users>>> Get([FromBody]long usersTypeID)
        {
            try
            {
                var result = await usersRepo.GetUsersByUserType(usersTypeID);
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
        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO?>> login(LoginBody loginbody)
        {
            try
            {
                var result = await usersRepo.login(loginbody);
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

    }
}
