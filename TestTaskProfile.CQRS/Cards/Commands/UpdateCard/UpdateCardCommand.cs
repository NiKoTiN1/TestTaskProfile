using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Commands.UpdateCard
{
    public record UpdateCardCommand(UpdateCardModel UpdateCardModel, Guid Id) : IRequest<GetCardModel>;
}
