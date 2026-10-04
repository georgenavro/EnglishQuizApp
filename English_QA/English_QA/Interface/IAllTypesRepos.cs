using Microsoft.AspNetCore.Mvc;

namespace English_QA.Interface
{
    public interface IAllTypesRepos<T>
    {
        public Task<T> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<List<T>> Get();
        public Task<bool> Delete(long id);


    }
}
