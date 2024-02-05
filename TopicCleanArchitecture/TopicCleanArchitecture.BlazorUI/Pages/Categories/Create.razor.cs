using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Models.Categories;

namespace TopicCleanArchitecture.BlazorUI.Pages.Categories
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        ICategoryService _client { get; set; }
        [Inject]
        IToastService toastService { get; set; }
        public string Message { get; private set; }

        CategoryVM category = new CategoryVM();
        async Task CreateCategory()
        {
            var response = await _client.CreateCategory(category);
            if (response.Success)
            {
                toastService.ShowSuccess("Category Created Successfully");
                _navManager.NavigateTo("/categories/");
            }
            Message = response.Message;
        }
    }
}