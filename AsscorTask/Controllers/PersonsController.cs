using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsscorTask.Models;
using AssecorTask.Application.Models;
using AssecorTask.Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AsscorTask.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService service;
        private readonly IMapper mapper;

        public PersonsController(IPersonService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetAllPersons()
        {
            var persons = await this.service.GetAllPersonsAsync();

            if (!persons.Any())
            {
                return this.NotFound();
            }

            return this.mapper.Map<IEnumerable<PersonViewModel>>(persons).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> GetPersonById(int id)
        {
            if (id <= 0)
            {
                return this.BadRequest();
            }

            var person = await this.service.GetPersonById(id);

            if(person == null)
            {
                return this.NotFound();
            }

            return this.mapper.Map<PersonViewModel>(person);
        }

        [HttpGet("color/{color}")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPersonByColor(string color)
        {
            var persons = await this.service.GetPersonsByColorAsync(color);

            if (!persons.Any())
            {
                return this.NotFound();
            }

            return this.mapper.Map<IEnumerable<PersonViewModel>>(persons).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<PersonViewModel>> CreatePerson(PersonInputModel personInputModel)
        {
            var model = this.mapper.Map<CreatePersonServiceModel>(personInputModel);

            var person = await this.service.CreatePersonAsync(model);

            if (person == null)
            {
                return this.BadRequest();
            }

            return this.Ok(this.mapper.Map<PersonViewModel>(person));
        }
    }
}
