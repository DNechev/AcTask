using System.Threading.Tasks;
using AssecorTask.Application.Interfaces;
using AssecorTask.Domain;
using AssecorTask.Persistance.EF;

namespace AssecorTask.Persistance
{
    public class AssecorTaskData : IData
    {
        private readonly AssecorTaskDbContext dbContext;
        public AssecorTaskData(AssecorTaskDbContext dbContext,
            IAsyncRepository<PersonEntity> persons,
            IAsyncRepository<ColorEntity> colors)
        {
            this.dbContext = dbContext;
            Persons = persons;
            Colors = colors;
        }

        public IAsyncRepository<PersonEntity> Persons { get; }

        public IAsyncRepository<ColorEntity> Colors { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
