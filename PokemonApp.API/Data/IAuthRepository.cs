using System.Threading.Tasks;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public interface IAuthRepository
    {
         Task<AppUser> Register(AppUser appUser, string password);

         Task<AppUser> Login(string username, string password);

         Task<bool> AppUserExists(string username);
    }
}