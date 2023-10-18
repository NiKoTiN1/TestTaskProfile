using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<GetUserModel>;
}
