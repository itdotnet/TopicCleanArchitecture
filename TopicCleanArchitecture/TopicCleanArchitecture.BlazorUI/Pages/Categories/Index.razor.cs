using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Models.Categories;
using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;

namespace TopicCleanArchitecture.BlazorUI.Pages.Categories
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }
        [Inject]
        IToastService toastService { get; set; }

        public List<CategoryVM> Categories { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateCategory()
        {
            NavigationManager.NavigateTo("/categories/create/");
        }

        protected void EditCategory(int id)
        {
            NavigationManager.NavigateTo($"/Categories/edit/{id}");
        }

        protected void DetailsCategory(int id)
        {
            NavigationManager.NavigateTo($"/categories/details/{id}");
        }

        protected async Task DeleteCategory(int id)
        {
            var response = await CategoryService.DeleteCategory(id);
            if (response.Success)
            {
                toastService.ShowSuccess("Category Deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }
    }
}