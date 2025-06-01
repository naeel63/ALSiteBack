using ALSiteBack.Dto;
using ALSiteBack.Models;
using AutoMapper;



namespace ALSiteBack.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                //.ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Group.Id))
                .ReverseMap();
            CreateMap<ActualDate, ActualDateDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
        
    }
}
