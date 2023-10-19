using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestTaskProfile.CQRS.Token.Queries.UpdateAccessToken;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.Web.Controllers
{
    [Authorize]
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
