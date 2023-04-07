
using HRBMSWEBAPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Data
{
    public class HRBMSDBCONTEXT : IdentityDbContext<ApplicationUser>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HRBMSDB;Integrated Security=True";
        //    optionsBuilder
        //        .UseSqlServer(connectionString)
        //        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.InvokeUserSeed();


        //    base.OnModelCreating(modelBuilder);
        //}
        public IConfiguration _appConfig { get; }
        public HRBMSDBCONTEXT(IConfiguration appConfig)
        {
            _appConfig = appConfig;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");
            var userName = _appConfig.GetConnectionString("UserName");
            var password = _appConfig.GetConnectionString("Password");
            string connectionString = $"Server={server};Database={db};User Id= {userName};Password={password};MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       
        //public DbSet<User> User { get; set; }

        public DbSet<Room> Room { get; set; }

        // public DbSet<Role> Role { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<RoomCategories> Categories { get; set; }

        public DbSet<Booking> Booking { get; set; }
    }
}
