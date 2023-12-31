﻿using AutoMapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using System.Web.Http;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.CQRS.Token.Commands.GenerateRefreshToken;
using TestTaskProfile.CQRS.Token.Commands.SaveRefreshToken;
using TestTaskProfile.CQRS.Users.Commands.DeleteUser;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, TokenModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserHandler(IUserRepository userRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        async Task<TokenModel> IRequestHandler<CreateUserCommand, TokenModel>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<User>(request.CreateUserViewModel);
            model.Password = Argon2.Hash(request.CreateUserViewModel.Password);

            var generateAccessTokenCommand = new GenerateAccessTokenCommand(model);
            var accessToken = await _mediator.Send(generateAccessTokenCommand);

            var generateRefreshTokenCommand = new GenerateRefreshTokenCommand(model);
            var refreshToken = await _mediator.Send(generateRefreshTokenCommand);

            refreshToken.UserId = model.Id;
            model.RefreshTokenId = refreshToken.Id;

            try
            {
                await _userRepository.CreateUser(model);
            }
            catch
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var saveRefreshTokenCommandModel = new SaveRefreshTokenCommand(refreshToken);
            var token = await _mediator.Send(saveRefreshTokenCommandModel);

            if(token == null)
            {
                var deleteUserCommandModel = new DeleteUserCommand(model.Id);
                await _mediator.Send(deleteUserCommandModel);

                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var tokenModel = new TokenModel()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token.ToString(),
            };

            return tokenModel;
        }
    }
}
