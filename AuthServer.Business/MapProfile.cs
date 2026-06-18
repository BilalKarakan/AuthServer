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
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}
