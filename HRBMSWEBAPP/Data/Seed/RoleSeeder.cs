using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class RoleSeeder
    {
        public static void InvokeRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {

                        Name = "Admin",
                        NormalizedName = "ADMIN"

                    },
                     new IdentityRole
                     {

                         Name = "Guest",
                         NormalizedName = "GUEST"
                     }
                ); 
        }
    }
}
