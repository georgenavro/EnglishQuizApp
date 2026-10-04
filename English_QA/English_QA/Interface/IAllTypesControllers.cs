using English_QA.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace English_QA.Interface
{
    public interface IAllTypesControllers<T>
    {
        public Task<ActionResult<List<T>>> Get();
        public Task<ActionResult> Add(T entity);
        public Task<ActionResult> Delete(long id);
        public Task<ActionResult> Update(T entity);
    }
}
