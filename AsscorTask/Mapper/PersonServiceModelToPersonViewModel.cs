using AsscorTask.Models;
using AssecorTask.Application.Models;
using AutoMapper;

namespace AsscorTask.Mapper
{
    public class PersonServiceModelToPersonViewModel : Profile
    {
        public PersonServiceModelToPersonViewModel()
        {
            CreateMap<PersonServiceModel, PersonViewModel>()
                .ForMember(p => p.Color, opt => opt.MapFrom(p => p.Color.Color));
            CreateMap<PersonInputModel, CreatePersonServiceModel>();
        }
    }
}
