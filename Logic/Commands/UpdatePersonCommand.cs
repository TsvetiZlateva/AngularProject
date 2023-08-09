using AutoMapper;
using Data.Data;
using Logic.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class UpdatePersonCommand : IRequest<Response<Guid>>
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string IBAN { get; set; }

        public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Response<Guid>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

            public UpdatePersonCommandHandler(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Response<Guid>> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
            {
                var person = await _db.People.FindAsync(command.PersonId);

                if (person == null)
                {
                    throw new NullReferenceException("Person Not Found.");
                }
                else
                {
                    person.FirstName = command.FirstName;
                    person.Surname = command.Surname;
                    person.DateOfBirth = command.DateOfBirth;
                    person.Address = command.Address;
                    person.Phone = command.Phone;
                    person.IBAN = command.IBAN;

                    await _db.SaveChangesAsync();

                    return new Response<Guid>(person.PersonId);
                }
            }
        }
    }
}
