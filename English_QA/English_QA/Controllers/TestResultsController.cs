using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Pagination;
using English_QA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace English_QA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestResultsController : ControllerBase, IAllTypesControllers<TestResults>
    {
        public TestResultsRepo testResultsRepo;
        public TestResultsController(TestResultsRepo testResults)
        {
            testResultsRepo = testResults;
        }
        [Authorize]
        [HttpPost("AddResult")]
        public async Task<ActionResult> AddResult(List<TestResults> entity)
        {
            try
            {
                var result = await testResultsRepo.Add(entity);

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
                var result = await testResultsRepo.Delete(id);

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
        [Authorize]
        [HttpDelete("DeleteAll")]
        public async Task<ActionResult> DeleteAllResults([FromBody] long userID)
        {
            try
            {
                var result = await testResultsRepo.DeleteAll(userID);

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
        [Authorize]
        [HttpGet("Get")]
        public async Task<ActionResult<List<TestResults>>> Get()
        {
            try
            {
                var result = await testResultsRepo.Get();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("GetAllTestResults")]
        public async Task<ActionResult<List<TestResults>>> GetAllTest([FromBody]long userID)
        {
            try
            {
                var result = await testResultsRepo.GetAllTestResults(userID);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("GetTestResultSelection")]
        public async Task<ActionResult<List<TestResults>>> GetSelectedTest(GetTestResultSelectionBody request)
        {
            try
            {
                var result = await testResultsRepo.GetTestResultSelection(request);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<ActionResult> Update(TestResults entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    return BadRequest();
                }
                var result = await testResultsRepo.Update(entity);

                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public Task<ActionResult> Add(TestResults entity)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Pagination")]
        public async Task<ActionResult<List<QA_PaginationDTO>>?> pagination([FromQuery] PaginationFilter filter, TestResults_PaginationBody body)
        {
            var route = Request.Path.Value ?? String.Empty;
            var result = await testResultsRepo.pagination(filter, route, body);

            if (result != null)
            {
                return Ok(result);
            }

            return null;
        }
    }
}
