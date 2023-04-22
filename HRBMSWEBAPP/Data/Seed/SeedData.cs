using HRBMSWEBAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class SeedData
    {

        public static void InvokeSeedAll(this ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<RoomCategories>()
                 .HasData(
                 new RoomCategories
                 {
                     Id = 1,
                     Room_Name = "Deluxe",
                     Description = "Spacious and luxurious accommodation option that offers guests an elevated level of comfort and sophistication. Typically located in upscale hotels and resorts, a Deluxe Room is designed to provide guests with an exceptional level of comfort and style.",
                     Price = 10000,
                 },
                 new RoomCategories
                 {
                     Id = 2,
                     Room_Name = "Normal",
                     Description = "Generally designed to accommodate one or two guests, with basic amenities such as a comfortable bed, a clean and well-appointed bathroom, and basic furnishings. Standard Rooms may also come equipped with a small work desk, a TV, and Wi-Fi access, providing guests with everything they need for a comfortable and productive stay.",
                     Price = 5000,
                 }

                 );

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
