using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken
{
    public record GenerateAccessTokenCommand(User User) : IRequest<string>;

}
