using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Queries.GetAllCards
{
    public record GetAllCardsQuery : IRequest<IEnumerable<GetCardModel>>;
}
