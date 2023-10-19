using MediatR;
using System.Web.Http;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.SaveRefreshToken
{
    public class SaveRefreshTokenHandler : IRequestHandler<SaveRefreshTokenCommand, RefreshToken>
    {
        private readonly ITokenRepository _tokenRepository;

        public SaveRefreshTokenHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<RefreshToken> Handle(SaveRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.SaveRefreshToken(request.RefreshToken);

            if (token == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            return token;
        }
    }
}
