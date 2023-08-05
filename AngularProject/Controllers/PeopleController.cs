using Data.Data;
using Data.Models;
using Logic.DTO;
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

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
           return _db.People.ToArray();
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();

            return Ok();
        }
    }
}
