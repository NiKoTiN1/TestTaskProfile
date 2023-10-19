using MediatR;

namespace TestTaskProfile.CQRS.Token.Queries.GetUserIdFromToken
{
    public record GetUserIdFromTokenQuery(string AccessToken) : IRequest<Guid>;
}
