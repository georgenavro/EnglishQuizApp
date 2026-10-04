using English_QA.Interface;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace English_QA.Repositories
{
    public class UserTypeRepo : IAllTypesRepos<Usertype>
    {
        public DBContext dbContext;

        public UserTypeRepo(DBContext dBContext)
        {
            dbContext = dBContext;
        }

        public async Task<Usertype> Add(Usertype entity)
        {
            try
            {
                dbContext.UserType.Add(entity);
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
                var entity = await dbContext.UserType.FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                dbContext.UserType.Remove(entity);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Usertype>> Get()
        {
            try
            {
                var entity = await dbContext.UserType.ToListAsync();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(Usertype entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    return false;
                }
                dbContext.UserType.Update(entity);
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
