using Microsoft.EntityFrameworkCore;
using PokemonApp.API.Models;

namespace PokemonApp.API.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            
        }

        public DbSet<Value> Values { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Photo> Photos { get; set; }
    }
}