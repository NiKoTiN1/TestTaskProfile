using Isopoh.Cryptography.Argon2;
using MediatR;
using System.Web.Http;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.CQRS.Token.Queries.GetRefreshTokenById;
using TestTaskProfile.CQRS.Users.Queries.GetUserByEmail;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.CQRS.Users.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, TokenModel>
    {
        private readonly IMediator _mediator;

        public LoginHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TokenModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var getUserByIdQuery = new GetUserByEmailQuery(request.LoginModel.Email);
            var user = await _mediator.Send(getUserByIdQuery);

            if (user == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var hashedPassword = Argon2.Hash(request.LoginModel.Password);

            if(Argon2.Verify(user.Password, hashedPassword))
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var getRefreshTokenByIdQuery = new GetRefreshTokenByIdQuery(user.RefreshTokenId);
            var refreshToken = await _mediator.Send(getRefreshTokenByIdQuery);

            if(refreshToken == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var generateAccessTokenCommandModel = new GenerateAccessTokenCommand(user);
            var accessToken = await _mediator.Send(generateAccessTokenCommandModel);

            var tokenModel = new TokenModel()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return tokenModel;
        }
    }
}
