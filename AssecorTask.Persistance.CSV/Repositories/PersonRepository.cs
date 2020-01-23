using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssecorTask.Application.Interfaces;
using AssecorTask.Domain;
using System.Linq;
using System.Reflection;

namespace AssecorTask.Persistance.CSV.Repositories
{
    public class PersonRepository : IAsyncRepository<PersonEntity>
    {
        private const string personRegex = @"([^,\r\n]+)[,\r\n ]+([^,\r\n]+)[,\r\n ]+([\d]+) ([^,\r\n]+)[,\r\n ]+([^,\r\n]+)[,\r\n ]+";
        private static readonly string dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "Data.csv");

        public Task<PersonEntity> AddAsync(PersonEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(PersonEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PersonEntity>> GetAllAsync()
        {
            var data = File.ReadAllText(dataPath);

            var match = Regex.Match(data, personRegex, RegexOptions.Multiline);

            var personsList = new List<PersonEntity>();

            var personId = 1;
            while (match.Success)
            {
                var personEntity = new PersonEntity
                {
                    Id = personId,
                    LastName = match.Groups[1].Value,
                    Name = match.Groups[2].Value,
                    ZipCode = match.Groups[3].Value,
                    City = match.Groups[4].Value,
                    ColorId = int.Parse(match.Groups[5].Value)
                };

                personsList.Add(personEntity);

                match = match.NextMatch();
                personId++;
            }

            return Task.FromResult<IEnumerable<PersonEntity>>(personsList);
        }

        public async Task<PersonEntity> GetByIdAsync(int id)
        {
            var persons = await GetAllAsync();

            var person = persons.SingleOrDefault(p => p.Id == id);

            return person;
        }

        public Task UpdateAsync(PersonEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
