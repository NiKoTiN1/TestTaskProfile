using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return await _tokenRepository.GetRefreshTokenById(request.Id);
        }
    }
}
