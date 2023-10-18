using MediatR;

namespace TestTaskProfile.CQRS.Token.Queries.GetUserIdFromToken
{
    public record GetUserIdFromTokenQuery(string accessToken) : IRequest<Guid>;
}
