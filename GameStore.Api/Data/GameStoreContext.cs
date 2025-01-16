using GameStore.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options)
        : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Fighting" },
                new { Id = 2, Name = "Action" },
                new { Id = 3, Name = "Adventure" },
                new { Id = 4, Name = "RPG" },
                new { Id = 5, Name = "Shooter" },
                new { Id = 6, Name = "Sports" },
                new { Id = 7, Name = "Strategy" },
                new { Id = 8, Name = "Simulation" },
                new { Id = 9, Name = "Puzzle" },
                new { Id = 10, Name = "Horror" },
                new { Id = 11, Name = "Music/Rhythm" },
                new { Id = 12, Name = "Racing" },
                new { Id = 13, Name = "Sandbox" },
                new { Id = 14, Name = "MMO" },
                new { Id = 15, Name = "Survival" }
            );
        }
    }
}
