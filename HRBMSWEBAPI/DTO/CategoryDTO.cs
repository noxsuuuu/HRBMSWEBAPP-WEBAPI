using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Price { get; set; }

        public string NumberOfRooms { get; set; }

        public CategoryDTO()
        {

        }

        public CategoryDTO(string name, string description, string price, string numberofRooms)
        {
            Name = name;
            Description = description;
            Price = price;
            NumberOfRooms = numberofRooms;
        }


    }
}
