using System.Collections.Generic;
using Newtonsoft.Json;
using PokemonApp.API.Helpers;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public class Seeder
    {
        private readonly AppDataContext _context;

        public Seeder(AppDataContext context)
        {
            _context = context;
        }

        public void SeedUsers() 
        {
            var data = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<AppUser>>(data);

            foreach(var user in users)
            {
                byte[] passwordHash, passwordSalt;
                PasswordHelper.GeneratePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.AppUsers.Add(user);
            }

            _context.SaveChanges();
        }
    }
}