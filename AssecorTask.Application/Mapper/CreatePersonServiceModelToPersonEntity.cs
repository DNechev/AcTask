using AssecorTask.Application.Models;
using AssecorTask.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssecorTask.Application.Mapper
{
    public class CreatePersonServiceModelToPersonEntity : Profile
    {
        public CreatePersonServiceModelToPersonEntity()
        {
            CreateMap<CreatePersonServiceModel, PersonEntity>();
            CreateMap<ColorEntity, ColorServiceModel>();
        }
    }
}
