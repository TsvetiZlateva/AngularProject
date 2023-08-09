using Data.Data;
using Data.Models;
using Logic.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class DeletePersonByIdCommand : IRequest<Response<Guid>>
    {
        public Guid PersonId { get; set; }

        public class DeletePersonByIdCommanddHandler : IRequestHandler<DeletePersonByIdCommand, Response<Guid>>
        {
            private readonly ApplicationDbContext _db;

            public DeletePersonByIdCommanddHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<Response<Guid>> Handle(DeletePersonByIdCommand command, CancellationToken cancellationToken)
            {
                var person = await _db.People.FindAsync(command.PersonId);               

                if (person == null)
                {
                    throw new NullReferenceException("Person Not Found.");
                }

                _db.Remove(person);
                await _db.SaveChangesAsync();

                return new Response<Guid>(person.PersonId);
            }
        }
    }
}
