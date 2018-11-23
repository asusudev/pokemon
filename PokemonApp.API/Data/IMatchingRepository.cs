using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public interface IMatchingRepository
    {
         void Add<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveAll();
         Task<IEnumerable<AppUser>> GetUsers();
         Task<AppUser> GetUser(int id);
    }
}