using HRBMSWEBAPP.Data.Seed;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data
{
    public class HRBMSDBCONTEXT : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HRBMSDB;Integrated Security=True";
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.InvokeUserSeed();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<RoomCategories> Categories { get; set; }

        public DbSet<Booking> Booking { get; set; }
    }
}
