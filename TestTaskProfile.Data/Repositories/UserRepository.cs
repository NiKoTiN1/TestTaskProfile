﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskProfile.Data.Interfaces;
using TestTaskProfile.Data.Models;

namespace TestTaskProfile.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid Id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(usr => usr.Id == Id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(usr => usr.Email == email);
        }

        public async Task<User> CreateUser(User user)
        {
            await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var dbUser = await _databaseContext.Users.FirstOrDefaultAsync(usr => usr.Id == user.Id);

            if (dbUser == null)
            {
                return null;
            }

            _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(Guid Id)
        {
            var dbUser = await _databaseContext.Users.FirstOrDefaultAsync(usr => usr.Id == Id);

            if (dbUser == null)
            {
                return;
            }

            _databaseContext.Users.Remove(dbUser);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
