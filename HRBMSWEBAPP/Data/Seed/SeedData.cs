using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Data.Seed
{
    public static class SeedData
    {

        public static void InvokeSeedAll(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Room>()
                .HasData(
                    new Room
                    {
                        Id = 1,
                        CategoryId = 1,
                        Floor_Number = 69,
                        Room_Number = 69,
                        
                    },
                    new Room
                    {
                        Id = 2,
                        CategoryId = 2,
                        Floor_Number = 61,
                        Room_Number = 61
                    }

                );


            modelBuilder
                .Entity<RoomCategories>()
                .HasData(
                    new RoomCategories
                    {
                        Id = 1,
                        Room_Name = "Deluxe",
                        NoOfRooms = 69,
                        Price = 69,
                        Description = "sheesh",
                    },
                    new RoomCategories
                    {
                        Id = 2,
                        Room_Name = "Normal",
                        NoOfRooms = 69,
                        Price = 69,
                        Description = "yeaaaaaaaa",
                    }

                );




        }

    }
}
