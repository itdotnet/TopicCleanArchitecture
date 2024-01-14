using AutoMapper;
using TopicCleanArchitecture.BlazorUI.Models.Categories;
using TopicCleanArchitecture.BlazorUI.Services.Base;

namespace TopicCleanArchitecture.BlazorUI.MappingProfiles
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDto, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryVM>().ReverseMap();
        }
    }
}
