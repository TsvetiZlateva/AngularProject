using Data.Data;
using Data.Models;
using Logic.Commands;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AngularProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await Mediator.Send(new GetPeopleQuery());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            return Ok(await Mediator.Send(new CreatePersonCommand
            {
                FirstName = person.FirstName,
                Surname = person.Surname,
                DateOfBirth = person.DateOfBirth,
                Address = person.Address,
                Phone = person.Phone,
                IBAN = person.IBAN,
            }));
        }

        [HttpPut]
        public IActionResult Put(Person person)
        {
            var personForUpdate = _db.People.Find(person.PersonId);

            if (personForUpdate != null)
            {
                personForUpdate.FirstName = person.FirstName;
                personForUpdate.Surname = person.Surname;
                personForUpdate.DateOfBirth = person.DateOfBirth;
                personForUpdate.Address = person.Address;
                personForUpdate.Phone = person.Phone;
                personForUpdate.IBAN = person.IBAN;

                _db.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string personId)
        {
            var personForDeletion = _db.People.Find(new Guid(personId));

            if (personForDeletion != null)
            {
                _db.Remove(personForDeletion);
                _db.SaveChanges();
            }

            return Ok();
        }
    }
}
