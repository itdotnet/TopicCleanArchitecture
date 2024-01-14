using TopicCleanArchitecture.BlazorUI.Models.Categories;
using TopicCleanArchitecture.BlazorUI.Services.Base;

namespace TopicCleanArchitecture.BlazorUI.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int id);
        Task<Response<Guid>> CreateCategory(CategoryVM category);
        Task<Response<Guid>> UpdateCategory(CategoryVM category);
        Task<Response<Guid>> DeleteCategory(int id);
    }
}
