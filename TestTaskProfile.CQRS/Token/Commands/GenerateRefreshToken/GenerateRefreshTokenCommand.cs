using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateRefreshToken
{
    public record GenerateRefreshTokenCommand(User User) : IRequest<RefreshToken>;
}
