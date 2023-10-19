using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Cards.Queries.GetCardById
{
    public class GetCardByIdHandler : IRequestHandler<GetCardByIdQuery, Card>
    {
        private readonly ICardRepository _cardRepository;

        public GetCardByIdHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cardRepository.GetCardById(request.Id);
        }
    }
}
