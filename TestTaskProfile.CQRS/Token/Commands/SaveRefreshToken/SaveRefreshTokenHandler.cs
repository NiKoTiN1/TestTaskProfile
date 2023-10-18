using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;

namespace TestTaskProfile.CQRS.Token.Commands.SaveRefreshToken
{
    public class SaveRefreshTokenHandler : IRequestHandler<SaveRefreshTokenCommand>
    {
        private readonly ITokenRepository _tokenRepository;
        public SaveRefreshTokenHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task Handle(SaveRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await _tokenRepository.SaveRefreshToken(request.RefreshToken);
        }
    }
}
