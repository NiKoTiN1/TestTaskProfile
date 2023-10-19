using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Cards.Queries.GetCardById
{
    public record GetCardByIdQuery(Guid Id) : IRequest<Card>;
}
