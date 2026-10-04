using English_QA.Models.DatabaseModels;
using English_QA.Interface;
using English_QA.Models;
using Microsoft.EntityFrameworkCore;
namespace English_QA.Repositories
{
    public class QuestionCategoryRepo : IAllTypesRepos<QuestionCategory>
    {
        public DBContext dbContext;

        public QuestionCategoryRepo(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }



        public async Task<QuestionCategory?> Add(QuestionCategory entity)
        {
            try
            {
                dbContext.Add(entity);
                await dbContext.SaveChangesAsync();

                return entity;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var entity = await dbContext.QuestionCategory.FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                dbContext.QuestionCategory.Remove(entity);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<List<QuestionCategory>> Get()
        {
            try
            {
                var entity = await dbContext.QuestionCategory.ToListAsync();
                return entity;
            }
            catch
            {
                return null;
            }



        }

        public async Task<bool> Update(QuestionCategory entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    return false;
                }
                dbContext.QuestionCategory.Update(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

