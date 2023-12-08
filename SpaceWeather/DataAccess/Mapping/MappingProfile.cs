using AutoMapper;
using Entity.DTO;
using SpaceWeather.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlanetDTO, Planet>()
                .ForMember(dest => dest.Raidus, opt => opt.MapFrom(src => Convert.ToInt16(src.Radius)));
            CreateMap<Planet, PlanetDTO>()
                .ForMember(dest => dest.Radius, opt => opt.MapFrom(src => Convert.ToInt16(src.Raidus)));

            CreateMap<SatelliteDTO, Satellite>()
                .ForMember(dest => dest.Raidus, opt => opt.MapFrom(src => Convert.ToInt16(src.Radius)))
            CreateMap<Satellite, SatelliteDTO>()
                .ForMember(dest => dest.Radius, opt => opt.MapFrom(src => Convert.ToInt16(src.Raidus)));
                
        }
    }
}
