using AutoMapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Repositories;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Commands.UpdateCard
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, GetCardModel>
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;

        public UpdateCardHandler(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        public async Task<GetCardModel> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var updateModel = request.UpdateCardModel;
            var card = await _cardRepository.GetCardById(request.Id);

            if (card == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(updateModel.Number))
            {
                card.Number = updateModel.Number;
            }

            if (!string.IsNullOrEmpty(updateModel.CardHolderName))
            {
                card.CardHolderName = updateModel.CardHolderName;
            }

            if (!string.IsNullOrEmpty(updateModel.CVV))
            {
                card.CVV = updateModel.CVV;
            }

            if (updateModel.Valid > DateTime.Now)
            {
                card.Valid = updateModel.Valid;
            }

            var newCard = await _cardRepository.UpdateCard(card);

            if (newCard == null)
            {
                return null;
            }

            return _mapper.Map<GetCardModel>(newCard);
        }
    }
}
