using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<GetUserModel>>;
}
