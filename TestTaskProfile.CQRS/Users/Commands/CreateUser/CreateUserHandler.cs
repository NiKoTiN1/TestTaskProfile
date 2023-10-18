using AutoMapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.CQRS.Token.Commands.GenerateRefreshToken;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, TokenViewModel>
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

        async Task<TokenViewModel> IRequestHandler<CreateUserCommand, TokenViewModel>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<User>(request.CreateUserViewModel);
            model.Password = Argon2.Hash(request.CreateUserViewModel.Password);

            var generateAccessTokenCommand = new GenerateAccessTokenCommand(model);
            var accessToken = await _mediator.Send(generateAccessTokenCommand);

            var generateRefreshTokenCommand = new GenerateRefreshTokenCommand(model);
            var refreshToken = await _mediator.Send(generateRefreshTokenCommand);

            model.RefreshToken = refreshToken;

            var result = await _userRepository.CreateUser(model);

            var tokenModel = new TokenViewModel()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token.ToString(),
            };
            return tokenModel;
        }
    }
}
