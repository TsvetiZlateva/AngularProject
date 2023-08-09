using AutoMapper;
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
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public PeopleController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetPeopleQuery()));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string personId)
        {     
            return Ok(await Mediator.Send(new DeletePersonByIdCommand { PersonId = new Guid(personId) }));
        }
    }
}
