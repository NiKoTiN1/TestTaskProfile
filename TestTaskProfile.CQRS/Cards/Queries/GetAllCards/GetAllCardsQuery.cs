using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Queries.GetAllCards
{
    public record GetAllCardsQuery : IRequest<IEnumerable<GetCardModel>>;
}
