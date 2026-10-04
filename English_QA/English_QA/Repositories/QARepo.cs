using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using English_QA.Pagination;
using English_QA.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace English_QA.Repositories
{
    public class QARepo
    {
        public DBContext dbContext;

        public UriService? iruService;

        public QARepo(DBContext dbcontext,UriService uri)
        {
            dbContext = dbcontext;
            iruService = uri;
        }

        public async Task<PagedResponse<List<QA_PaginationDTO>>> pagination(PaginationFilter filter,string route,QA_PaginationBody qa_Pagination) 
        {

            var data = dbContext.QA
                .Where(qag => qa_Pagination.questionCategoryID == qag.questionCategoryID && qa_Pagination.AnswerTypeID == qag.AnswerTypeID)
                .Select(qag => new QA
                {
                    Id = qag.Id,
                    Question = qag.Question,
                    Answer = qag.Answer,
                    MultipleAnswer01 = qag.MultipleAnswer01,
                    MultipleAnswer02 = qag.MultipleAnswer02,
                    MultipleAnswer03 = qag.MultipleAnswer03,
                    MultipleAnswer04 = qag.MultipleAnswer04,
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

            List<QA_PaginationDTO> qa_List = new List<QA_PaginationDTO>();   

            foreach(var item in pagedData)
            {
                QA_PaginationDTO qa_data = new QA_PaginationDTO();

                qa_data.Id = item.Id;
                qa_data.Answer = item.Answer;
                qa_data.Question = item.Question;
                qa_data.QuestionCategory = item.questionCategory.questionCategory;
                qa_data.AnswerType = item.answerType.AnswerType;
                qa_data.MultipleAnswer01 = item.MultipleAnswer01;
                qa_data.MultipleAnswer02 = item.MultipleAnswer02;
                qa_data.MultipleAnswer03 = item.MultipleAnswer03;
                qa_data.MultipleAnswer04 = item.MultipleAnswer04;

                qa_List.Add(qa_data);
            }
           
            return PaginationResult.PagedResponse(qa_List,filter,total_Records,iruService,route);
        }

        public async Task<bool> Update(QA entity)
        {
            try
            {
                var qa = await dbContext.QA.FindAsync(entity.Id);
                
                if(qa == null)
                {
                    return false;
                }

                var properties = typeof(QA).GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.Name != nameof(QA.Id));

                foreach (var prop in properties)
                {
                    var value = prop.GetValue(entity);

                    if (value == null)
                        continue;

                    // strings
                    if (prop.PropertyType == typeof(string) &&
                        string.IsNullOrWhiteSpace(value as string))
                        continue;

                    // value types (int, bool, etc.)
                    if (prop.PropertyType.IsValueType &&
                        value.Equals(Activator.CreateInstance(prop.PropertyType)))
                        continue;

                    prop.SetValue(qa, value);
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var exist = dbContext.QA.Find(id);

                if (exist == null)
                {
                    return false;
                }
                dbContext.QA.Remove(exist);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<QA?> Add(QA entity)
        {
            try
            {
                dbContext.QA.Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                return null;
            }
        }

    }
}
