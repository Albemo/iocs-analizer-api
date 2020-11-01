using AutoMapper;
using iocs_analizer_api.Dtos;
using iocs_analizer_api.Models;

namespace iocs_analizer_api.Profiles
{
    public class IocsProfile : Profile
    {
        public IocsProfile()
        {
            //Source -> Target
            CreateMap<Ioc, IocReadDto>();
            CreateMap<IocCreateDto, Ioc>();
            CreateMap<IocUpdateDto, Ioc>();
        }
    }
}