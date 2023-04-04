using HRBMSWEBAPP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class RoleSeeder
    {
        public static void InvokeRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RoleViewModel>()
                .HasData(
                    new RoleViewModel
                    {
                        Name = "Admin",
                    },
                     new RoleViewModel
                     {
                         Name = "Staff",
                     }
                );
        }
    }
}
