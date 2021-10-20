using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class PokeMatchDb : DbContext
    {
        public PokeMatchDb() : base () { }

        public PokeMatchDb(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
