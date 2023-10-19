using MediatR;
using System.Security.Cryptography;
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
