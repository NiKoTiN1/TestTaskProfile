using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.SaveRefreshToken
{
    public record SaveRefreshTokenCommand(RefreshToken RefreshToken) : IRequest<RefreshToken>;
}
