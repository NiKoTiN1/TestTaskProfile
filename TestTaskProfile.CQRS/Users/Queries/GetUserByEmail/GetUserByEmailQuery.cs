using MediatR;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Users.Queries.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email) : IRequest<User>;
}
