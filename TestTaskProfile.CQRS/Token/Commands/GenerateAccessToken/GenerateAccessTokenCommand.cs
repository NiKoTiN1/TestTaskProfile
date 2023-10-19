using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken
{
    public record GenerateAccessTokenCommand(User User) : IRequest<string>;

}
