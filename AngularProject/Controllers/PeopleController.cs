using Data.Data;
using Data.Models;
using Logic.DTO;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Post(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();

            return Ok();
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
