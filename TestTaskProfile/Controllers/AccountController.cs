using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskProfile.CQRS.Users.Commands.CreateUser;
using TestTaskProfile.CQRS.Users.Commands.DeleteUser;
using TestTaskProfile.CQRS.Users.Commands.UpdateUser;
using TestTaskProfile.CQRS.Users.Queries.GetAllUsers;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.CQRS.Users.Queries.Login;
using TestTaskProfile.ViewModels.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTaskProfile.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getall")]
        public async Task<IEnumerable<GetUserModel>> GetAll()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<TokenModel> Login([FromBody] LoginModel model)
        {
            var command = new LoginQuery(model);
            return await _mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<TokenModel> CreateUser([FromBody] CreateUserModel model)
        {
            var command = new CreateUserCommand(model);
            return await _mediator.Send(command);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserModel model)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId");

            if (string.IsNullOrEmpty(userIdClaim.Value))
            {
                return Unauthorized();
            }

            if(userIdClaim.Value != id.ToString())
            {
                return Forbid();
            }

            model.Id = id;
            var updateUserCommandModel = new UpdateUserCommand(model);
            return Ok(await _mediator.Send(updateUserCommandModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId");

            if (string.IsNullOrEmpty(userIdClaim.Value))
            {
                return Unauthorized();
            }

            if (userIdClaim.Value != id.ToString())
            {
                return Forbid();
            }

            var deleteUserCommandModel = new DeleteUserCommand(id);
            await _mediator.Send(deleteUserCommandModel);

            return Ok();
        }
    }
}
