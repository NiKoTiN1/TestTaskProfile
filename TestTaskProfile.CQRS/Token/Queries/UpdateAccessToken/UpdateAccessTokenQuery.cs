using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Token.Queries.UpdateAccessToken
{
    public record UpdateAccessTokenQuery(TokenModel TokenModel) : IRequest<TokenModel>;
}
