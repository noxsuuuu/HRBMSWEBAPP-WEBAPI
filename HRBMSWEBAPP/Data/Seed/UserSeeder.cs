using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class UserSeeder
    {
        public static void InvokeUserSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasData(
                     new User
                     {
                         Id = 1,
                         First_Name = "admin",
                         RoleId = 1,
                     },
                    new User
                    {
                        Id = 2,
                        First_Name = "Ivhan",
                        Last_Name = "De Leon",
                        Email = "ivhan@gmail.com",
                        Phone = "09079260368",
                        RoleId = 2,
                        Address = "Rizal, PH"
                    },
                     new User
                     {
                         Id = 3,
                         First_Name = "Mark",
                         Last_Name = "Mayaman",
                         Email = "mark@gmail.com",
                         Phone = "09125635896",
                         RoleId = 3,
                         Address = "Las Pinas, PH"
                     }
                );
        }
    }
}
