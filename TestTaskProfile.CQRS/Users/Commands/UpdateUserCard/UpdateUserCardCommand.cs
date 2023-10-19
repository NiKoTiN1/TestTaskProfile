using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUserCard
{
    public record UpdateUserCardCommand(User User, Guid CardId) : IRequest<User>;
}
