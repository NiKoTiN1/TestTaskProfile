using MediatR;
using System.Web.Http;
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
            var card = await _cardRepository.GetCardById(request.Id);

            if(card == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return card;
        }
    }
}
