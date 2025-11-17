using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<College, CollegeDto>().ReverseMap();
        }
    }
}
