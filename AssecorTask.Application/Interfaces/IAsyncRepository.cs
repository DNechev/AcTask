using System.Collections.Generic;
using System.Threading.Tasks;
using AssecorTask.Domain;

namespace AssecorTask.Application.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
