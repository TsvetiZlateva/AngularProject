using AutoMapper;
using Data.Models;
using Logic.Commands;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonCommand, Person>().ReverseMap();
        }
    }
}
