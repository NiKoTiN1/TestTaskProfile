using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskProfile.CQRS.Users.Commands.CreateUser;
using TestTaskProfile.CQRS.Users.Commands.DeleteUser;
using TestTaskProfile.CQRS.Users.Commands.UpdateUser;
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
        public async Task<GetUserModel> GetById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        // POST api/<CreateUser>
        [HttpPost]
        public async Task<TokenModel> CreateUser([FromBody] CreateUserModel model)
        {
            var command = new CreateUserCommand(model);
            return await _mediator.Send(command);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<GetUserModel> Put(Guid id, [FromBody] UpdateUserModel model)
        {
            model.Id = id;
            var updateUserCommandModel = new UpdateUserCommand(model);
            return await _mediator.Send(updateUserCommandModel);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var deleteUserCommandModel = new DeleteUserCommand(id);
            await _mediator.Send(deleteUserCommandModel);
        }
    }
}
