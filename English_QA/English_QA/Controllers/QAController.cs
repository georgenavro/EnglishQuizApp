using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Pagination;
using English_QA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QAController : ControllerBase
    {
        public QARepo _qaRepo;
        public QAController(QARepo qa_repo) 
        {
            _qaRepo = qa_repo;
        }
        [Authorize]
        [HttpPost("Pagination")]
        public async Task<ActionResult<List<QA_PaginationDTO>>?> pagination_QA([FromQuery]PaginationFilter filter,QA_PaginationBody qa_body)
        {
            var route = Request.Path.Value?? String.Empty;
            var result = await _qaRepo.pagination(filter,route, qa_body);

            if(result != null)
            {
                return Ok(result);
            }

            return null;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult> Add(QA entity)
        {
            try
            {            
                var result = await  _qaRepo.Add(entity);

                return Created("",result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(QA entity)
        {
            try
            {
                if(entity.Id == 0)
                {
                    return BadRequest();
                }
                var result = await _qaRepo.Update(entity);

                return Ok(result);

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
                var result = await _qaRepo.Delete(id);

                if(result != true)
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
        //[HttpPost("GenerateTest")]
        //public async Task<ActionResult> GenerateTest(QA_GenerationTestBody request)
        //{
        //    try
        //    {
        //        var results = await _qaRepo.GenerateTest(request);

        //        if(results == null) 
        //        {
        //            return BadRequest();
        //        }

        //        return Ok(results);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


    }
}
