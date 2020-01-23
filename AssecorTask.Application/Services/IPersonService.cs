using System.Collections.Generic;
using System.Threading.Tasks;
using AssecorTask.Application.Models;

namespace AssecorTask.Application.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonServiceModel>> GetAllPersonsAsync();

        Task<PersonServiceModel> GetPersonById(int id);

        Task<IEnumerable<PersonServiceModel>> GetPersonsByColorAsync(string color);

        Task<PersonServiceModel> CreatePersonAsync(CreatePersonServiceModel createPersonServiceModel);
    }
}
