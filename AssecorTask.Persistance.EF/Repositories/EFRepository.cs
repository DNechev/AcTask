using System.Collections.Generic;
using System.Threading.Tasks;
using AssecorTask.Application.Interfaces;
using AssecorTask.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssecorTask.Persistance.EF.Repositories
{
    public class EFRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly AssecorTaskDbContext dbContext;

        public EFRepository(AssecorTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<T> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);

            return Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
