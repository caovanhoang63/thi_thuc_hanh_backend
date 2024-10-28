using AutoMapper;
using test_mvc.Models.DTOs;
using test_mvc.Models.Entities;

namespace test_mvc.Mappings;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<ProductCreate, Product>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
        CreateMap<ProductUpdate, Product>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
        CreateMap<CategoryCreate, Category>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
        
        CreateMap<Category, CategoryList >()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
        CreateMap<UserCreate, User>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
        CreateMap<User, UserList>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        
    }
}