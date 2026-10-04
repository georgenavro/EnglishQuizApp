using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace English_QA.Repositories
{
    public class UserTestRepo : IAllTypesRepos<UserTest>
    {
        public DBContext dBContext;
        public UriService? iruService;
        public UserTestRepo(DBContext dBContext,UriService uriService) 
        {
            this.dBContext = dBContext;
            iruService = uriService;
        }
        
        public async Task<bool> Delete([FromBody]long id)
        {
            try
            {
                var minID = id - 9;
                var maxID = id;

                var exist = await dBContext.UserTest
                    .Where(ut => ut.Id >= minID && ut.Id <= maxID)
                    .ToListAsync();
                var testResultExist = await dBContext.TestResults
                    .Where(ut=> ut.UserTestID <= maxID && ut.UserTestID >= minID)
                    .ToListAsync();

                if (exist == null || testResultExist.Count != 0)
                {
                    return false;
                }

                foreach (var item in exist) {

                    dBContext.UserTest.Remove(item);
                }
                await dBContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<UserTest>> Get()
        {
            try
            {
                var result = await dBContext.UserTest.ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }

        }

        public async Task<List<GetPreviousUserTestDTO>> GetPreviousUserTests([FromBody] long userID)
        {
            try
            {
                var i = 1;
                var result = await dBContext.UserTest.Where
                    (us=> us.UserID == userID).ToListAsync();
                List<GetPreviousUserTestDTO> data = new List<GetPreviousUserTestDTO>();
                
                foreach(var item in result)
                {
                    GetPreviousUserTestDTO GetUserTest = new GetPreviousUserTestDTO();
                    
                    i++;
                    if(i > 10)
                    {
                        GetUserTest.Id = item.Id;
                        GetUserTest.UserID = item.UserID;
                        GetUserTest.AnswerTypeID = item.AnswerTypeID;
                        GetUserTest.QuestionCategoryID = item.questionCategoryID;
                        GetUserTest.TestCount = item.TestCount;
                        data.Add(GetUserTest);
                        i = 1;
                    }
                    
                }
                
                    
                return data;
            }
            catch
            {
                return null;
            }
            
        }
        public async Task<List<UserGeneratedTestDTO>> GetUserTestSelection(GetUserTestSelectionBody request)
        {
            try
            {
                var firstQuestionID = request.Id - 9;
                var result = await dBContext.UserTest.Where
                    (us => us.UserID == request.userID &&
                    us.questionCategoryID == request.questionCategoryID &&
                    us.AnswerTypeID == request.answerTypeID &&
                    us.Id >= firstQuestionID && us.Id <= request.Id).ToListAsync();
                    
                List<UserGeneratedTestDTO> testAdded = new List<UserGeneratedTestDTO>();

                
                foreach (var item in result)
                {
                    UserGeneratedTestDTO GetUserTestSelection = new UserGeneratedTestDTO();
                    if (request.answerTypeID == 1)
                    {
                        GetUserTestSelection.Question = item.Question;
                        GetUserTestSelection.AnswerTypeID = item.AnswerTypeID;
                        GetUserTestSelection.TestCount = item.TestCount;
                        GetUserTestSelection.Id = item.Id;
                    }
                    else
                    {
                        GetUserTestSelection.Question = item.Question;
                        GetUserTestSelection.AnswerTypeID = item.AnswerTypeID;
                        GetUserTestSelection.TestCount = item.TestCount;
                        GetUserTestSelection.Id = item.Id;
                        GetUserTestSelection.MultipleAnswer01 = item.MultipleAnswer01;
                        GetUserTestSelection.MultipleAnswer02 = item.MultipleAnswer02;
                        GetUserTestSelection.MultipleAnswer03 = item.MultipleAnswer03;
                        GetUserTestSelection.MultipleAnswer04 = item.MultipleAnswer04;

                    }
                        testAdded.Add(GetUserTestSelection);
                        
                
                }


                return testAdded;
            }
            catch
            {
                return null;
            }

        }
        public async Task<bool> Update(UserTest entity)
        {
            try
            {

                dBContext.UserTest.Update(entity);
                await dBContext.SaveChangesAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }
        public async Task<ActionResult<List<UserGeneratedTestDTO>>?> GenerateTest(QA_GenerationTestBody request)
        {
            var data = await dBContext.QA
               .Where(qas => qas.questionCategoryID == request.questionCategoryID && qas.AnswerTypeID == request.AnswerTypeID)
               .ToListAsync();

            if (data.Count() < request.quantity)
            {
                return null;
            }
            Random rnd = new Random();

            var shuffleQuestions = data.OrderBy(q => rnd.Next()).Take(request.quantity);

            //var latestUserTestQuestions = await dBContext.UserTest
            //    .Where(us => us.AnswerTypeID == request.AnswerTypeID &&
            //    us.questionCategoryID == request.questionCategoryID &&
            //    us.UserID == request.userID)
            //    .OrderByDescending(us => us.Id)
            //    .FirstOrDefaultAsync();

            var latestUserTestQuestions = await dBContext.UserTest
                .OrderByDescending(us => us.Id)
                .ToListAsync();

            var latestTestCount = latestUserTestQuestions
                .Where(ut => ut.UserID == request.userID)
                .FirstOrDefault();

            if (latestTestCount == null)
            {
                latestTestCount = new UserTest
                {
                    TestCount = 0,
                };
            }

            if(latestUserTestQuestions.Count == 0)
            {
                latestUserTestQuestions.Add(new UserTest { Id = 0 });
            }
            
            List<UserGeneratedTestDTO> qa_Test = new List<UserGeneratedTestDTO>();

            var ID = latestUserTestQuestions.FirstOrDefault().Id +1;
            //latestTestCount.Id +1 : latestUserTestQuestions.FirstOrDefault().Id +1;
            
                foreach (var resultsAdded in shuffleQuestions)
                {

                    UserTest results = new UserTest();
                    UserGeneratedTestDTO qa_data = new UserGeneratedTestDTO();

                    results.Id = ID;
                    results.Question = resultsAdded.Question;
                    results.Answer = resultsAdded.Answer;
                    results.MultipleAnswer01 = resultsAdded.MultipleAnswer01;
                    results.MultipleAnswer02 = resultsAdded.MultipleAnswer02;
                    results.MultipleAnswer03 = resultsAdded.MultipleAnswer03;
                    results.MultipleAnswer04 = resultsAdded.MultipleAnswer04;
                    results.questionCategoryID = request.questionCategoryID;
                    results.AnswerTypeID = request.AnswerTypeID;
                    results.UserID = request.userID;
                    results.TestCount = latestTestCount.TestCount + 1;
                if (request.AnswerTypeID == 1) {

                    qa_data.AnswerTypeID = resultsAdded.AnswerTypeID;
                    qa_data.TestCount = latestTestCount.TestCount + 1;
                    qa_data.Question = resultsAdded.Question;
                    qa_data.Id = ID;// Retrieve the ID of the latest inserted question entry from the userTest table.
                                    // After the user submits their answers, we fetch the corresponding ID from the userTest table.
                                    // Note: resultsAdded.id always refers to the question ID (ranging from 1 to 20) in the QA table.
                    
                }
                else
                {
                    qa_data.AnswerTypeID = resultsAdded.AnswerTypeID;
                    qa_data.TestCount = latestTestCount.TestCount + 1;
                    qa_data.Question = resultsAdded.Question;
                    qa_data.Id = ID;
                    qa_data.MultipleAnswer01 = resultsAdded.MultipleAnswer01;
                    qa_data.MultipleAnswer02 = resultsAdded.MultipleAnswer02;
                    qa_data.MultipleAnswer03 = resultsAdded.MultipleAnswer03;
                    qa_data.MultipleAnswer04 = resultsAdded.MultipleAnswer04;

                }
                    ID++;
                    qa_Test.Add(qa_data);

                    dBContext.UserTest.Add(results);

                }


                await dBContext.SaveChangesAsync();
           

                return qa_Test;
        }

        public Task<UserTest> Add(UserTest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<UserTest_PaginationDTO>>> pagination(PaginationFilter filter, string route, UserTest_PaginationBody userTest_Pagination)
        {

            var data = dBContext.UserTest
                .Where(qag => userTest_Pagination.questionCategoryID == qag.questionCategoryID && 
                userTest_Pagination.answerTypeID == qag.AnswerTypeID && userTest_Pagination.userID == qag.UserID)
                .Select(qag => new UserTest
                {
                    Id = qag.Id,
                    Question = qag.Question,
                    Answer = qag.Answer,
                    MultipleAnswer01 = qag.MultipleAnswer01,
                    MultipleAnswer02 = qag.MultipleAnswer02,
                    MultipleAnswer03 = qag.MultipleAnswer03,
                    MultipleAnswer04 = qag.MultipleAnswer04,
                    TestCount = qag.TestCount,
                    UserID = qag.UserID,
                    User = new Users
                    {
                        Username = qag.User.Username,
                    },
                    questionCategory = new QuestionCategory
                    {
                        questionCategory = qag.questionCategory.questionCategory,
                    },
                    answerType = new AnswerTypes
                    {
                        AnswerType = qag.answerType.AnswerType,
                    }
                });

            var total_Records = data.Count();

            var pagedData = await data
                .Skip((filter.pageNumber - 1) * filter.pageSize)
                .Take(filter.pageSize)
                .ToListAsync();

            List<UserTest_PaginationDTO> userTest_List = new List<UserTest_PaginationDTO>();

            foreach (var item in pagedData)
            {
                UserTest_PaginationDTO userTest_data = new UserTest_PaginationDTO();

                userTest_data.Id = item.Id;
                userTest_data.Answer = item.Answer;
                userTest_data.Question = item.Question;
                userTest_data.QuestionCategory = item.questionCategory.questionCategory;
                userTest_data.AnswerType = item.answerType.AnswerType;
                userTest_data.MultipleAnswer01 = item.MultipleAnswer01;
                userTest_data.MultipleAnswer02 = item.MultipleAnswer02;
                userTest_data.MultipleAnswer03 = item.MultipleAnswer03;
                userTest_data.MultipleAnswer04 = item.MultipleAnswer04;
                userTest_data.UserID = item.UserID;
                userTest_data.UserName = item.User.Username;
                userTest_data.TestCount = item.TestCount;

                userTest_List.Add(userTest_data);
            }

            return PaginationResult.PagedResponse(userTest_List, filter, total_Records, iruService, route);
        }
    }
}
