using Data.Data;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries
{
    public class GetPeopleQuery : IRequest<IEnumerable<Person>>
    {
        
    }

    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, IEnumerable<Person>>
    {       
        private readonly ApplicationDbContext _db;

        public GetPeopleQueryHandler(ApplicationDbContext db)
        {           
            _db = db;
        }

        public async Task<IEnumerable<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            return await _db.People.ToListAsync();
        }
    }
}
