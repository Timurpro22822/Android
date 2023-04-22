using ASP.NET_Web_API.Data.Entites;
using ASP.NET_Web_API.Models;
using AutoMapper;

namespace ASP.NET_Web_API.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<CategoryEntity, CategoryItemViewModel>()
                .ForMember(x => x.Image, opt => opt.MapFrom(x => $"/images/{x.Image}"));

            CreateMap<CategoryCreateItemVM, CategoryEntity>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ForMember(x => x.DateCreated,
                    opt => opt.MapFrom(x => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)));
        }
    }
}
