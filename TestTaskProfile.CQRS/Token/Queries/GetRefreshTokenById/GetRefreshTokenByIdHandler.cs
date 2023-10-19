using MediatR;
using System.Web.Http;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Queries.GetRefreshTokenById
{
    public class GetRefreshTokenByIdHandler : IRequestHandler<GetRefreshTokenByIdQuery, RefreshToken>
    {
        private readonly ITokenRepository _tokenRepository;

        public GetRefreshTokenByIdHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<RefreshToken> Handle(GetRefreshTokenByIdQuery request, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.GetRefreshTokenById(request.Id);

            if (token == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            }

            return token;
        }
    }
}
