﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Users.Commands.UpdateUserCard
{
    public record UpdateUserCardCommand(User User, Guid CardId) : IRequest<User>;
}