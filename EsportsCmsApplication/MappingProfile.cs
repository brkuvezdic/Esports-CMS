using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;

namespace EsportsCmsApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<College, CollegeDto>().ReverseMap();
            CreateMap<CreateCollegeDto, College>();
            CreateMap<UpdateCollegeDto, College>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CollegeId, opt => opt.MapFrom(src => src.CollegeId));

            CreateMap<Game, GameDto>().ReverseMap();

            CreateMap<Team, TeamDto>();
            CreateMap<CalendarEvent, CalendarEventDto>();

            CreateMap<CreateCalendarEventDto, CalendarEvent>();

            CreateMap<UpdateCalendarEventDto, CalendarEvent>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
