using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssecorTask.Application.Interfaces;
using AssecorTask.Application.Models;
using AssecorTask.Domain;
using AutoMapper;

namespace AssecorTask.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IData data;
        private readonly IMapper mapper;

        public PersonService(IData data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PersonServiceModel>> GetAllPersonsAsync()
        {
            var persons = await this.data.Persons.GetAllAsync();
            var colors = await this.data.Colors.GetAllAsync();
            var personServiceModels = this.mapper.Map<IEnumerable<PersonServiceModel>>(persons);

            foreach (var person in personServiceModels)
            {
                var color = colors.FirstOrDefault(c => c.Id == person.ColorId);
                person.Color = this.mapper.Map<ColorServiceModel>(color);
            }

            return personServiceModels;
        }

        public async Task<PersonServiceModel> GetPersonById(int id)
        {
            var person = await this.data.Persons.GetByIdAsync(id);

            if(person == null)
            {
                return null;
            }

            var personServiceModel = this.mapper.Map<PersonServiceModel>(person);

            var color = await this.data.Colors.GetByIdAsync(person.ColorId);
            var colorServiceModel = this.mapper.Map<ColorServiceModel>(color);

            personServiceModel.Color = colorServiceModel;

            return personServiceModel;
        }

        public async Task<IEnumerable<PersonServiceModel>> GetPersonsByColorAsync(string color)
        {
            var persons = await this.data.Persons.GetAllAsync();
            var colors = await this.data.Colors.GetAllAsync();
            var personServiceModels = this.mapper.Map<IEnumerable<PersonServiceModel>>(persons);

            foreach (var person in personServiceModels)
            {
                person.Color = this.mapper.Map<ColorServiceModel>(colors.FirstOrDefault(c => c.Id == person.ColorId));
            }

            personServiceModels = personServiceModels.Where(p => p.Color.Color == color).ToList();

            return personServiceModels;
        }

        public async Task<PersonServiceModel> CreatePersonAsync(CreatePersonServiceModel createPersonServiceModel)
        {
            var personToAdd = this.mapper.Map<PersonEntity>(createPersonServiceModel);
            
            await this.data.Persons.AddAsync(personToAdd);

            await this.data.SaveChangesAsync();

            var personServiceModel = this.mapper.Map<PersonServiceModel>(personToAdd);
            var color = await this.data.Colors.GetByIdAsync(personToAdd.ColorId);
            personServiceModel.Color = this.mapper.Map<ColorServiceModel>(color);

            return personServiceModel;
        }
    }
}
