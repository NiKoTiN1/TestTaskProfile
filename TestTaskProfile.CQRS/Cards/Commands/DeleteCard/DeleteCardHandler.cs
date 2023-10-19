using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.CQRS.Cards.Queries.GetCardById;
using TestTaskProfile.CQRS.Users.Commands.UpdateUserCard;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.Data.Interfaces;

namespace TestTaskProfile.CQRS.Cards.Commands.DeleteCard
{
    public class DeleteCardHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMediator _mediator;

        public DeleteCardHandler(ICardRepository cardRepository, IMediator mediator)
        {
            _cardRepository = cardRepository;
            _mediator = mediator;
        }

        public async Task Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var getCardByIdQueryModel = new GetCardByIdQuery(request.DeleteCardModel.CardId);
            var card = await _mediator.Send(getCardByIdQueryModel);

            if (card == null)
            {
                return;
            }

            if(card.UserId !=  request.DeleteCardModel.UserId)
            {
                return;
            }

            await _cardRepository.DeleteCard(request.DeleteCardModel.CardId);

            var getUserByIdModel = new GetUserByIdQuery(request.DeleteCardModel.UserId);
            var user = await _mediator.Send(getUserByIdModel);
            
            if (user == null)
            {
                return;
            }

            var updateUserCardCommandModel = new UpdateUserCardCommand(user, Guid.Empty);
            await _mediator.Send(updateUserCardCommandModel);
        }
    }
}
