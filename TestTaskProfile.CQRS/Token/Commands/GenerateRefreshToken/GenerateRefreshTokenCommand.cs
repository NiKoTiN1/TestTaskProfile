using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateRefreshToken
{
    public record GenerateRefreshTokenCommand(User User) : IRequest<RefreshToken>;
}
