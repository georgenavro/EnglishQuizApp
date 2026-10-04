using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace English_QA.Repositories
{
    public class AnswerTypeRepo : IAllTypesRepos<AnswerTypes>
    {
        public DBContext dbContext;

        public AnswerTypeRepo(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }



        public async Task<AnswerTypes?> Add(AnswerTypes entity)
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
                var entity = await dbContext.AnswerTypes.FindAsync(id);

                if(entity == null)
                {
                    return false;
                }

                dbContext.AnswerTypes.Remove(entity);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
           

        }

        public async Task<List<AnswerTypes>> Get()
        {
            try
            {
                var entity = await dbContext.AnswerTypes.ToListAsync();
                return entity;
            }
            catch
            {
                return null;
            }
            


        }

        public async Task<bool> Update(AnswerTypes entity)
        {
            try
            {
                if(entity.Id == 0)
                {
                    return false;
                }
                dbContext.AnswerTypes.Update(entity);
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
