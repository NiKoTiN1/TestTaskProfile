using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UpdateUserModel Model) : IRequest<GetUserModel>;
}
