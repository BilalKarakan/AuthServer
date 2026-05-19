using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AutoMapper;

namespace AuthServer.Business;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<AppUser, AppUserDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
