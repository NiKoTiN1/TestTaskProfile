using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskProfile.CQRS.Cards.Commands.AddCard;
using TestTaskProfile.CQRS.Cards.Commands.DeleteCard;
using TestTaskProfile.CQRS.Cards.Commands.UpdateCard;
using TestTaskProfile.CQRS.Cards.Queries.GetAllCards;
using TestTaskProfile.CQRS.Cards.Queries.GetCardById;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var cards = await _mediator.Send(new GetAllCardsQuery());
            return Ok(cards);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getCardByIdQueryModel = new GetCardByIdQuery(id);
            var card = await _mediator.Send(getCardByIdQueryModel);

            return Ok(card);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCard([FromBody] AddCardModel model)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId");

            if (string.IsNullOrEmpty(userIdClaim.Value))
            {
                return Unauthorized();
            }

            var addCardCommandModel = new AddCardCommand(model, Guid.Parse(userIdClaim.Value));
            var card = await _mediator.Send(addCardCommandModel);

            return Ok(card);
        }

        [HttpPut("{id}")]
        [Route("update")]
        public async Task<IActionResult> UpdateCard(Guid id, [FromBody] UpdateCardModel model)
        {
            var updateCardCommandModel = new UpdateCardCommand(model, id);
            var newCard = await _mediator.Send(updateCardCommandModel);
            return Ok(newCard);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveCard(Guid id)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId");

            if (string.IsNullOrEmpty(userIdClaim.Value))
            {
                return Unauthorized();
            }

            var model = new DeleteCardModel()
            {
                UserId = Guid.Parse(userIdClaim.Value),
                CardId = id
            };

            var deleteCardCommandModel = new DeleteCardCommand(model);
            await _mediator.Send(deleteCardCommandModel);

            return Ok(model);
        }
    }
}
