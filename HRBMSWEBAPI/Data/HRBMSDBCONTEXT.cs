using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRBMSWEBAPI.Models;


namespace HRBMSWEBAPI.Data 
{
    public class HRBMSDBCONTEXT : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public HRBMSDBCONTEXT(IConfiguration appConfig)
        {
            _appConfig = appConfig;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            /*var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");
            var userName = _appConfig.GetConnectionString("UserName");
            var password = _appConfig.GetConnectionString("Password");
            string connectionString = $"Server={server};Database={db};User Id={userName};Password={password};MultipleActiveResultSets=true"; // Server ={server}; Database ={db}; User Id={userName}; Password={password}; MultipleActiveResultSets=true
            */
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HRBMSDB; ";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Room> Room { get; set; }


       // public DbSet<Invoice> Invoice { get; set; }

        public DbSet<RoomCategories> Categories { get; set; }

        public DbSet<Booking> Booking { get; set; }
    }
}
