using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.CQRS.Token.Queries.GetRefreshTokenById;
using TestTaskProfile.CQRS.Token.Queries.GetUserIdFromToken;
using TestTaskProfile.CQRS.Token.Queries.UpdateAccessToken;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel model)
        {
            var updateAccessTokenQueryModel = new UpdateAccessTokenQuery(model);
            var tokenModel = await _mediator.Send(updateAccessTokenQueryModel);

            if (tokenModel == null)
            {
                return BadRequest();
            }

            return Ok(tokenModel);
        }
    }
}
