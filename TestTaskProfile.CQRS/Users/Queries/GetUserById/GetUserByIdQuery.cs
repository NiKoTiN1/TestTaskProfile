using MediatR;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<User>;
}
