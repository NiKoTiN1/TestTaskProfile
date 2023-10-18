﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.CQRS.Token.Queries.GetRefreshTokenById;
using TestTaskProfile.CQRS.Token.Queries.GetUserIdFromToken;
using TestTaskProfile.CQRS.Users.Queries.GetUserById;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Token.Queries.UpdateAccessToken
{
    public class UpdateAccessTokenHandler : IRequestHandler<UpdateAccessTokenQuery, TokenModel>
    {
        private readonly IMediator _mediator;

        public UpdateAccessTokenHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TokenModel> Handle(UpdateAccessTokenQuery request, CancellationToken cancellationToken)
        {
            var model = request.tokenModel;
            if (model.RefreshToken == null || string.IsNullOrEmpty(model.RefreshToken))
            {
                return null;
            }
            if (model.AccessToken == null || string.IsNullOrEmpty(model.AccessToken))
            {
                return null;
            }

            var getUserIdFromTokenQuery = new GetUserIdFromTokenQuery(model.AccessToken);
            var userId = await _mediator.Send(getUserIdFromTokenQuery);

            var getUserByIdQuery = new GetUserByIdQuery(userId);
            var user = await _mediator.Send(getUserByIdQuery);

            var getRefreshTokenByIdQuery = new GetRefreshTokenByIdQuery(user.RefreshTokenId);
            var refreshToken = await _mediator.Send(getRefreshTokenByIdQuery);

            bool isRefreshTokenValid = ValidateRefreshToken(refreshToken, model.RefreshToken);

            if (!isRefreshTokenValid)
            {
                return null;
            }

            var generateAccessTokenModel = new GenerateAccessTokenCommand(user);
            var newAccessToken = await _mediator.Send(generateAccessTokenModel);

            if (newAccessToken == null)
            {
                return null;
            }

            model.AccessToken = newAccessToken;
            return model;
        }

        private bool ValidateRefreshToken(RefreshToken dbToken, string refreshToken)
        {
            if (dbToken == null || dbToken.Token != refreshToken)
            {
                return false;
            }

            if (DateTime.UtcNow > dbToken.Expiration)
            {
                return false;
            }

            return true;
        }
    }
}