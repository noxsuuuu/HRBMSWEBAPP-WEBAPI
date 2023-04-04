using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class UserSeeder
    {
        public static void InvokeUserSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ApplicationUser>()
                .HasData(
                     new ApplicationUser
                     {
                         //Id = 1,
                         FirstName = "Admin",
                         LastName = "Manager",
                         Email = "admin@gmail.com",
                         PhoneNumber = "09079260368",
                         //Address = "Rizal, PH"
                     },
                    new ApplicationUser
                    {
                        //Id = 2,
                        FirstName = "Ivhan",
                        LastName = "De Leon",
                        Email = "ivhan@gmail.com",
                        PhoneNumber = "09079260368",
                        //Address = "Rizal, PH"
                    },
                     new ApplicationUser
                     {
                         //Id = 3,
                         FirstName = "Mark",
                         LastName = "Mayaman",
                         Email = "mark@gmail.com",
                         PhoneNumber = "09125635896",
                         //Address = "Las Pinas, PH"
                     }
                );

            //modelBuilder
            //    .Entity<RegisterViewModel>()
            //    .HasData(
            //         new RegisterViewModel
            //         {
            //             Id = 1,
            //             First_Name = "admin",
            //             Last_Name = "admin",
            //             Email = "admin@gmail.com",
            //             Phone = "09079260368",
            //             RoleId = 1,
            //             Address = "Rizal, PH"
            //         },
        }
    }
}
