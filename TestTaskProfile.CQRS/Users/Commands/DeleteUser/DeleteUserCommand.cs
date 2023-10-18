using MediatR;

namespace TestTaskProfile.CQRS.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest;
}
