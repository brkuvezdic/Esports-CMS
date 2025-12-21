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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateCollegeDto, College>();
            CreateMap<UpdateCollegeDto, College>().ForAllMembers(opts => opts.Condition((src, dest, srcMember)=> srcMember !=null));

        }
    }
}
