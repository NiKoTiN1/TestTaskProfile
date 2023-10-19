using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.Data.Interfaces
{
    public interface ITokenRepository
    {
        Task<RefreshToken> GetRefreshTokenById(Guid id);
        Task<RefreshToken> SaveRefreshToken(RefreshToken refreshToken);
    }
}
