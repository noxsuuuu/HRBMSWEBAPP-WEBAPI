using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.ViewModel
{
    public class CreateRoomViewModel
    {
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public List<RoomCategories> Categories { get; set; }
    }
}
