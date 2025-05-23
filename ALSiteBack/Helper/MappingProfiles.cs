using ALSiteBack.Dto;
using ALSiteBack.Models;
using AutoMapper;



namespace ALSiteBack.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ActualDate, ActualDateDto>().ReverseMap();
        }
        
    }
}
