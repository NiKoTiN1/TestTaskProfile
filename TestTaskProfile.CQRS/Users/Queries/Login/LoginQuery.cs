using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.Login
{
    public record LoginQuery(LoginModel LoginModel) : IRequest<TokenModel>;
}
