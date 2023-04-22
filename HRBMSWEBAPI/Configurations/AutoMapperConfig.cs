using AutoMapper;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<RoomCategories, RoomCategoriesDTO>().ReverseMap();
        }

    }
}
