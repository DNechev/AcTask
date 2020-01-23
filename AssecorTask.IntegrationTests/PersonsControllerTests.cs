using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AsscorTask;
using AsscorTask.Models;
using AssecorTask.IntegrationTests.Constants;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace AssecorTask.IntegrationTests
{
    public class PersonsControllerTests
    {
        private readonly HttpClient client;

        public PersonsControllerTests()
        {
            this.client = new AssecorTaskWebApplicationFactory<Startup>().CreateClient();
        }

        [Fact]
        public async Task SuccessfullyGetPersonsTest()
        {
            var personsCount = 10;

            for (var i = 0; i < personsCount; i++)
            {
                await CreatePerson();
            }

            var response = await this.client.GetAsync(EndPoint.PersonsBaseUrl);

            var content = await response.Content.ReadAsStringAsync();

            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonViewModel>>(content);

            Assert.Equal(personsCount, persons.Count());
        }

        [Fact]
        public async Task SuccessfullyGetPersonByIdTest()
        {
            var request = CreatePersonInputModel();

            await CreatePerson(request);

            var response = await this.client.GetAsync($"{EndPoint.PersonsBaseUrl}/1");
            var content = JsonConvert.DeserializeObject<PersonViewModel>(await response.Content.ReadAsStringAsync());

            Assert.Equal(request.City, content.City);
            Assert.Equal("blau", content.Color);
            Assert.Equal(request.Name, content.Name);
            Assert.Equal(request.ZipCode, content.ZipCode);
        }

        [Fact]
        public async Task SuccessfullyGetPersonsByColorTest()
        {
            var redColorPersonsCount = 5;
            var blueColorPersonsCount = 5;

            for (var i = 0; i < redColorPersonsCount; i++)
            {
                await CreatePerson(CreatePersonInputModel(2));
            }

            for (var i = 0; i < blueColorPersonsCount; i++)
            {
                await CreatePerson(CreatePersonInputModel(1));
            }

            var response = await this.client.GetAsync($"{EndPoint.PersonsBaseUrl}/color/blau");
            var content = JsonConvert.DeserializeObject<IEnumerable<PersonViewModel>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(blueColorPersonsCount, content.Count());

            content.ToList().ForEach(p => Assert.Equal("blau", p.Color));
        }

        [Fact]
        public async Task SuccessfullyCreatePersonTest()
        {
            var request = CreatePersonInputModel();

            var response = await CreatePerson(request);

            Assert.Equal(request.City, response.City);
            Assert.Equal("blau", response.Color);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.ZipCode, response.ZipCode);
        }

        private PersonInputModel CreatePersonInputModel(int colorId = 1)
        {
            var personInputModel = new Faker<PersonInputModel>()
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.ColorId, f => colorId)
                .RuleFor(p => p.Name, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
                .Generate();

            return personInputModel;
        }

        private async Task<PersonViewModel> CreatePerson(PersonInputModel personInputModel)
        {
            var json = JsonConvert.SerializeObject(personInputModel);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this.client.PostAsync(EndPoint.PersonsBaseUrl, content);

            var responseStringContent = await response.Content.ReadAsStringAsync();

            var responseContent = JsonConvert.DeserializeObject<PersonViewModel>(responseStringContent);

            return responseContent;
        }

        private async Task<PersonViewModel> CreatePerson()
        {
            return await CreatePerson(CreatePersonInputModel());
        }
    }
}
