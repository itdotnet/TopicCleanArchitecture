using AutoMapper;
using Blazored.LocalStorage;
using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Models.Categories;
using TopicCleanArchitecture.BlazorUI.Services.Base;

namespace TopicCleanArchitecture.BlazorUI.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateCategory(CategoryVM category)
        {
            try
            {
                await AddBearerToken();
                var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(category);
                await _client.CategoriesPOSTAsync(createCategoryCommand);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteCategory(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.CategoriesDELETEAsync(id);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<CategoryVM>> GetCategories()
        {
            await AddBearerToken();
            var categories = await _client.CategoriesAllAsync();
            return _mapper.Map<List<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetCategoryDetails(int id)
        {
            await AddBearerToken();
            var category =await _client.CategoriesGETAsync(id);
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<Response<Guid>> UpdateCategory(CategoryVM category)
        {
            try
            {
                await AddBearerToken();
                var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
                await _client.CategoriesPUTAsync(updateCategoryCommand);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
