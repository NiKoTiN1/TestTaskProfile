using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Isopoh.Cryptography.Argon2;
using TestTaskProfile.Services.Interfaces;

namespace TestTaskProfile.Services.Services
{
    public class UserService : IUserService
    {
        public string HashPassword(string password)
        {
            return Argon2.Hash(password);
        }
    }
}
