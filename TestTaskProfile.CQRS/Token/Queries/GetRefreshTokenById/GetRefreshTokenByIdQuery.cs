using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Queries.GetRefreshTokenById
{
    public record GetRefreshTokenByIdQuery(Guid Id) : IRequest<RefreshToken>;
}
