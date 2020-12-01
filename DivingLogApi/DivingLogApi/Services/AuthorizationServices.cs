using DivingLogApi.Data;
using DivingLogApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingLogApi.Services
{
    public class AuthorizationServices : IAuthorizationServices
    {

        private readonly DivingLogContext context;


        public AuthorizationServices(DivingLogContext context)
        {
            this.context = context;
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(name => name.Login == login);

            if (user is null)
            {
                return null;
            }

            var passwordIsCorrect = IsPasswordCorrect(password, user.PasswordHash, user.PasswordSalt);

            if (!passwordIsCorrect)
            {
                return null;
            }

            return user;
        }

        private bool IsPasswordCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public Task<bool> UserExist(string login)
        {
            return context.Users.AnyAsync(user => user.Login == login);
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHashSalt(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
