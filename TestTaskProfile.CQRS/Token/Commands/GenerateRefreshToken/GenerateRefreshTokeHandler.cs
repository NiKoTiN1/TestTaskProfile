using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokeHandler : IRequestHandler<GenerateRefreshTokenCommand, RefreshToken>
    {
        public async Task<RefreshToken> Handle(GenerateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                Expiration = DateTime.UtcNow.AddMonths(3)
            };
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            return await Task.FromResult(refreshToken);
        }
    }
}
