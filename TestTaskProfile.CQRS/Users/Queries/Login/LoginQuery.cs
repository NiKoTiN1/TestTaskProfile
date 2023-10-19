using MediatR;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.Login
{
    public record LoginQuery(LoginModel LoginModel) : IRequest<TokenModel>;
}
