using AutoMapper;
using Data.Models;
using Logic.Commands;

namespace Logic.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonCommand, Person>().ReverseMap();
            CreateMap<UpdatePersonCommand, Person>().ReverseMap();
        }
    }
}
