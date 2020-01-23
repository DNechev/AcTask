using AssecorTask.Application.Models;
using AssecorTask.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssecorTask.Application.Mapper
{
    public class PersonEntityToPersonServiceModelProfile : Profile
    {
        public PersonEntityToPersonServiceModelProfile()
        {
            CreateMap<PersonEntity, PersonServiceModel>();
        }
    }
}
