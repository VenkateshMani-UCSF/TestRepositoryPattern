using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRepositoryPattern.Domain
{
     public interface IRepository<T> where T : class
     {
          Task<IEnumerable<T>> GetAll();
          Task<T> Get(string id);
          Task<T> Add(T entity);
          Task<T> Update(T entity);
          Task<T> Delete(string id);
     }
}
