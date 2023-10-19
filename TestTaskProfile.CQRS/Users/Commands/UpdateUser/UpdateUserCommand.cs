using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UpdateUserModel Model) : IRequest<GetUserModel>;
}
