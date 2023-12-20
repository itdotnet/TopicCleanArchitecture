using AutoMapper;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetCategoryDetails;
using TopicCleanArchitecture.Domain;

namespace TopicCleanArchitecture.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<Category, CategoryDetailsDto>();
        }
    }
}
