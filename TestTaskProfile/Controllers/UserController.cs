using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskProfile.CQRS.Users.Commands.CreateUser;
using TestTaskProfile.CQRS.Users.Queries.GetAllUsers;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.ViewModels.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTaskProfile.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<GetUserModel>> Get()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<GetUserModel> Get(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        // POST api/<CreateUser>
        [HttpPost]
        public async Task<TokenViewModel> CreateUser([FromBody] CreateUserViewModel model)
        {
            var command = new CreateUserCommand(model);
            return await _mediator.Send(command);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
