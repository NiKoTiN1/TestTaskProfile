using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.CreateUser
{
    public record CreateUserCommand(CreateUserModel CreateUserViewModel) : IRequest<TokenModel>;
}
