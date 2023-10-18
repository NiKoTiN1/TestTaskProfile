using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task SaveRefreshToken(RefreshToken refreshToken)
        {
            await _databaseContext.RefreshTokens.AddAsync(refreshToken);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
