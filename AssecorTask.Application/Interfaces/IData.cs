using System.Threading.Tasks;
using AssecorTask.Domain;

namespace AssecorTask.Application.Interfaces
{
    public interface IData
    {
        IAsyncRepository<PersonEntity> Persons { get; }

        IAsyncRepository<ColorEntity> Colors { get; }

        Task<int> SaveChangesAsync();
    }
}
