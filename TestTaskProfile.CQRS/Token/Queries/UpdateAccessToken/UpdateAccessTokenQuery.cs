using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Token.Queries.UpdateAccessToken
{
    public record UpdateAccessTokenQuery(TokenModel tokenModel) : IRequest<TokenModel>;
}
