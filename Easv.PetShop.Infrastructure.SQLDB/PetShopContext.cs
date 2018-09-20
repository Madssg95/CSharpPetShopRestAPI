using Easv.PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Easv.PetShop.Infrastructure.SQLDB
{
    public class PetShopContext : DbContext
    {
        //what kind of database do we work with? -> calling the suoerclass constructor with : base()
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
        }

        // two tables in the db with their columns and also the relation between these two tables
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //en owner har mange pets og et pet har en owner -> hvis jeg sletter en kunde, så skriver den null i pets owner feld
            modelbuilder.Entity<Owner>().HasMany(o => o.Pets).WithOne(p => p.Owner).OnDelete(DeleteBehavior.SetNull);

        }




    }
}