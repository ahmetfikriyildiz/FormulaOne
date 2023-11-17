using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Data
{
    public class AppDbContext:DbContext
    {
        // define the db entities
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achivement> Achivements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {
            this.Database.Migrate();
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //specified the relationship between the entities

            modelBuilder.Entity<Achivement>(entity =>
            {
              // Assuming Id is the primary key in Achivement
                entity.HasOne(d => d.Driver)
                     .WithMany(p => p.Achivements)
                     .HasForeignKey(d => d.DriverId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .HasConstraintName("FK_Achivements_Driver");
            }
         );
       
      }
    }
}
