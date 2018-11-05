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
        public DbSet<Color> Colors { get; set; }
        public DbSet<PetColor> PetColors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //en owner har mange pets og et pet har en owner -> hvis jeg sletter et pet, så skriver den null i pets owner feld
            modelbuilder.Entity<Pet>().HasOne(p => p.Owner).WithMany(o => o.Pets).OnDelete(DeleteBehavior.SetNull);

            modelbuilder.Entity<PetColor>().HasKey(pc => new {pc.ColorId, pc.PetId});

            modelbuilder.Entity<PetColor>().HasOne<Pet>(pc => pc.Pet).WithMany(p => p.PetColors).HasForeignKey(pc => pc.PetId);
            
            modelbuilder.Entity<PetColor>().HasOne<Color>(pc => pc.Color).WithMany(c => c.PetColors).HasForeignKey(pc => pc.ColorId);

        }
    }
}