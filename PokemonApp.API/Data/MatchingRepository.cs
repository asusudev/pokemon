using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public class MatchingRepository : IMatchingRepository
    {
        private readonly AppDataContext _context;

        public MatchingRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<AppUser> GetUser(int id)
        {
            var user = await _context.AppUsers.Include(u => u.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = await _context.AppUsers.Include(u => u.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}