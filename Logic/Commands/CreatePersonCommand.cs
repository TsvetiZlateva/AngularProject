using AutoMapper;
using Data.Data;
using Data.Models;
using Logic.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class CreatePersonCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; }        
        public string Surname { get; set; }        
        public DateTime DateOfBirth { get; set; }        
        public string Address { get; set; }       
        public string Phone { get; set; }        
        public string IBAN { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Response<Guid>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            await _db.People.AddAsync(person);
            await _db.SaveChangesAsync();
            
            return new Response<Guid>(person.PersonId);
        }
    }
}
