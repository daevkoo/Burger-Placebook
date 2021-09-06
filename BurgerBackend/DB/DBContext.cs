using System.Data.Entity;
using BurgerBackend.Models;

namespace BurgerBackend.DB
{
    public class BBDBContext : DbContext
    {
        public BBDBContext() { }

        public DbSet<BurgerPlace> BurgerPlaces { get; set; }
        public DbSet<ReviewScore> Reviews { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Code for modell configuration
        }
    }
}