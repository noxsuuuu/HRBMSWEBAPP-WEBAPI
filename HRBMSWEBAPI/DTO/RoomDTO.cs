using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class RoomDTO
    {
        [Required]
        public int Floor_Number { get; set; }
        public int Room_Number { get; set; }
        public int Category_Id { get; set; }

        public RoomDTO()
        {

        }

        public RoomDTO(int floor_number, int room_number, int cat_Id)
        {
            Floor_Number = floor_number;
            Room_Number = room_number;
            Category_Id = cat_Id;
        }
    }
}
