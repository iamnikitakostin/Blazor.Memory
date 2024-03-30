using BlazorCardGame.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCardGame.Data
{
    public class CardGameDb : DbContext
    {
        public CardGameDb (DbContextOptions<CardGameDb> options) : base(options) { }

        public DbSet<Cardgame> Games { get; set; }
    }
}
