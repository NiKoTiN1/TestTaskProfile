using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Queries.GetAllCards
{
    public class GetAllCardsHandler : IRequestHandler<GetAllCardsQuery, IEnumerable<GetCardModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;

        public GetAllCardsHandler(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<GetCardModel>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var dbCards = await _cardRepository.GetAllCards();
            return _mapper.Map<IEnumerable<GetCardModel>>(dbCards);
        }
    }
}
