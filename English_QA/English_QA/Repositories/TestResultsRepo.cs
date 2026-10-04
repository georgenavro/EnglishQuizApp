using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace English_QA.Repositories
{
    public class TestResultsRepo : IAllTypesRepos<TestResults>
    {
        public DBContext dbContext;
        float score;
        public UriService? iruService;
        public TestResultsRepo(DBContext dBContext,UriService uriService) 
        {
            dbContext = dBContext;
            iruService = uriService;
        }
        public async Task<TestResults> Add(List<TestResults> entity)
        {
            

            try
            {

                long minId = ((entity[0].UserTestID - 1) / 10) * 10 + 1;
                long maxId = minId + 9;
                //We are making this request because we want to review the questions and be able to assign a score to it.
                var request = await dbContext.UserTest
                      .Where(ust => ust.Id >= minId && ust.Id <= maxId).ToListAsync();
                // First, we retrieve all data (all columns) from the test results table.
                // Later, we process this data to separate individual results.
                
                var testResults = await dbContext.TestResults.ToListAsync();

                var lastAttemptByTestID = testResults
                        .Where(us=> us.UserTestID >= minId && us.UserTestID <= maxId)
                        .Select(us => new TestResults
                        {
                            TestPerAttempt = us.TestPerAttempt,
                            UserTestID = us.UserTestID,
                            UserTest = new UserTest
                            {
                                Id = us.UserTest.Id,
                                UserID = us.UserTest.UserID
                            }
                        })
                        .ToList();

                var getTheLastAttempt = lastAttemptByTestID.OrderByDescending(us=> us.TestPerAttempt).FirstOrDefault();
                var lastTestCount = testResults.OrderByDescending(us=>us.TestResultCount).FirstOrDefault();
                if (getTheLastAttempt == null)
                {
                    getTheLastAttempt = new TestResults
                    {
                        TestPerAttempt = 0
                    };
                }
                if(lastTestCount == null)
                {
                    lastTestCount = new TestResults
                    {
                        TestResultCount = 0
                    };
                }
                
                UserTest userTest = new UserTest();

                foreach(var item in entity) { 
                    
                    var result = request.Where(us => us.Id == item.UserTestID).FirstOrDefault();

                    if (result != null)
                    {
                        item.CorrectAnswers = result.Answer.ToLower() == item.UserAnswer.ToLower() ? 1 : 0;
                    }

                    score += item.CorrectAnswers * item.CountQuestions;
                    item.Results = score;

                    item.TestPerAttempt = getTheLastAttempt.TestPerAttempt + 1;
                    item.TestResultCount = lastTestCount.TestResultCount + 1;
                    dbContext.TestResults.Add(item);

                }
                await dbContext.SaveChangesAsync();
                return entity[0];
            }
            catch
            {
                return null;
            }
          
        }

        public async Task<bool> Delete([FromBody]long testResultCount)
        {
            try
            {
                var exist = await dbContext.TestResults.Where(tr => tr.TestResultCount == testResultCount).ToListAsync();

                if (exist == null)
                {
                    return false;
                }
                foreach (var item in exist)
                {
                    dbContext.TestResults.Remove(item);
                 
                }
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteAll([FromBody]long userID)
        {
            try
            {
                var exist = await dbContext.TestResults
                    .Where(ut=> ut.UserTest.UserID == userID)
                    .ToListAsync();

                if (exist == null)
                {
                    return false;
                }
                foreach (var item in exist)
                {
                    dbContext.TestResults.Remove(item);

                }
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TestResults>> Get()
        {
            try
            {
                var result = await dbContext.TestResults.ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<TestResults>> GetAllTestResults([FromBody]long userID)
        {
            try
            {
                var result = await dbContext.TestResults
                    .Select(us => new TestResults
                    {
                        Id = us.Id,
                        UserTestID = us.UserTestID,
                        Results = us.Results,
                        TestPerAttempt = us.TestPerAttempt,
                        TestResultCount = us.TestResultCount,
                        UserTest = new UserTest
                        {
                            UserID = us.UserTest.UserID,
                            TestCount = us.UserTest.TestCount
                            
                        }
                    })
                    .Where(us => us.UserTest.UserID == userID)
                    .OrderByDescending(us => us.Id)
                    .ToListAsync();
                
                List<TestResults> resultList = new List<TestResults>();
                long testResultCount = 0;

                foreach (var item in result)
                {
                    TestResults testResults = new TestResults();

                    if (item.TestResultCount != testResultCount)
                    {
                        long minId = ((item.UserTestID - 1) / 10) * 10 + 1;
                        long maxId = (minId + 9) / 10;
                        testResultCount = item.TestResultCount;
                        testResults.Id = item.Id;
                        testResults.Results = item.Results;
                        testResults.UserTestID = maxId;
                        testResults.TestPerAttempt = item.TestPerAttempt;
                        testResults.TestResultCount = item.TestResultCount;
                        testResults.UserTest = new UserTest {
                            TestCount = item.UserTest.TestCount
                        };
                        resultList.Add(testResults);
                    }
                    
                }

                var OrderAttempts = resultList
                .OrderBy(oa => oa.Id)
                .ToList();

                return OrderAttempts;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> Update(TestResults entity)
        {
            try
            {

                dbContext.TestResults.Update(entity);
                await dbContext.SaveChangesAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }
        
        public async Task<List<TestResults>> GetTestResultSelection(GetTestResultSelectionBody request)
        {
            try
            {
                
                var result = await dbContext.TestResults
                    .Where(us => us.UserTest.UserID == request.userID &&
                    us.TestResultCount == request.testResultCount)
                    .Include(us=> us.UserTest).ToListAsync();
                
                
                return result;
            }
            catch
            {
                return null;
            }
        }

        public Task<TestResults> Add(TestResults entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<TestResults_PaginationDTO>>> pagination(PaginationFilter filter, string route, TestResults_PaginationBody testResults_Pagination)
        {

            var data = dbContext.TestResults
                .Where(qag => testResults_Pagination.userID == qag.UserTest.UserID)
                .Select(qag => new TestResults
                {
                    Id = qag.Id,
                    UserAnswer = qag.UserAnswer,
                    CorrectAnswers = qag.CorrectAnswers,
                    CountQuestions = qag.CountQuestions,
                    Results = qag.Results,
                    UserTestID = qag.UserTestID,
                    TestPerAttempt = qag.TestPerAttempt,
                    UserTest = new UserTest
                    {
                        Question = qag.UserTest.Question,
                        Answer = qag.UserTest.Answer,
                        UserID = qag.UserTest.UserID,
                    
                        User = new Users
                        {
                            Username = qag.UserTest.User.Username
                        }
                    }
                })
                .OrderBy(tr => tr.Id);

            var total_Records = data.Count();

            var pagedData = await data
                .Skip((filter.pageNumber - 1) * filter.pageSize)
                .Take(filter.pageSize)
                
                .ToListAsync();

            List<TestResults_PaginationDTO> testResults_List = new List<TestResults_PaginationDTO>();

            foreach (var item in pagedData)
            {
                TestResults_PaginationDTO testResult = new TestResults_PaginationDTO();

                testResult.ID = item.Id;
                testResult.Question = item.UserTest.Question;
                testResult.Answer = item.UserTest.Answer;
                testResult.UserAnswer = item.UserAnswer;
                testResult.CorrectAnswers = item.CorrectAnswers;
                testResult.CountQuestions = item.CountQuestions;
                testResult.Results = item.Results;
                testResult.UserID = item.UserTest.UserID;
                testResult.UserName = item.UserTest.User.Username;
                testResult.TestPerAttempt = item.TestPerAttempt;

                testResults_List.Add(testResult);
            }

            return PaginationResult.PagedResponse(testResults_List, filter, total_Records, iruService, route);
        }
    }
}
