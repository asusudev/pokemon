using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonApp.API.Helpers;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDataContext _context;

        public AuthRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<bool> AppUserExists(string username)
        {
            if(await _context.AppUsers.AnyAsync(u => u.Username == username))
            {
                return true;
            }

            return false;
        }

        public async Task<AppUser> Login(string username, string password)
        {
            var appUser = await _context.AppUsers.FirstOrDefaultAsync(u => u.Username == username);

            if(appUser == null)
            {
                return null;
            } 

            if(!VerifyPasswordHash(password, appUser.PasswordHash, appUser.PasswordSalt))
            {
                return null;
            }

            return appUser;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public async Task<AppUser> Register(AppUser appUser, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            PasswordHelper.GeneratePasswordHash(password, out passwordHash, out passwordSalt);

            appUser.PasswordHash = passwordHash;
            appUser.PasswordSalt = passwordSalt;

            await _context.AppUsers.AddAsync(appUser);

            await _context.SaveChangesAsync();

            return appUser;
        }
    }
}