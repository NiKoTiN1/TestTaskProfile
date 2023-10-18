using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.Services.Interfaces
{
    public interface IUserService
    {
        string HashPassword(string password);
    }
}
