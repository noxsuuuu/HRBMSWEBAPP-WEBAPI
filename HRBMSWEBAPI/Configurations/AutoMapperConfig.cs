using AutoMapper;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<RoomCategories, RoomCategoriesDTO>().ReverseMap();
        }

    }
}
