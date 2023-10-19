using Microsoft.EntityFrameworkCore;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TokenRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<RefreshToken> GetRefreshTokenById(Guid id)
        {
            return await _databaseContext.RefreshTokens.FirstOrDefaultAsync(token => token.Id == id);
        }

        public async Task<RefreshToken> SaveRefreshToken(RefreshToken refreshToken)
        {
            await _databaseContext.RefreshTokens.AddAsync(refreshToken);
            await _databaseContext.SaveChangesAsync();
            return refreshToken;
        }
    }
}
