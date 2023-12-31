﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestTaskProfile.CQRS.Cards.Commands.DeleteCard;
using TestTaskProfile.CQRS.Users.Commands.UpdateUserCard;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Cards.Commands.AddCard
{
    public class AddCardHandler : IRequestHandler<AddCardCommand, GetCardModel>
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;
        private readonly IMediator _mediator;

        public AddCardHandler(IMapper mapper,
            ICardRepository cardRepository,
            IMediator mediator)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
            _mediator = mediator;
        }
        public async Task<GetCardModel> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var getUserByIdQueryModel = new GetUserByIdQuery(request.UserId);
            var user = await _mediator.Send(getUserByIdQueryModel);

            if (user == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var card = _mapper.Map<Card>(request.AddCardModel);

            card.UserId = request.UserId;
            user.CardId = card.Id;

            var createdCard = await _cardRepository.AddCard(card);

            var updateUserCardCommandModel = new UpdateUserCardCommand(user, card.Id);
            var updatedUser = await _mediator.Send(updateUserCardCommandModel);

            if (updatedUser == null)
            {
                await _cardRepository.DeleteCard(card.Id);
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var cardModel = _mapper.Map<GetCardModel>(createdCard);

            return cardModel;
        }
    }
}
