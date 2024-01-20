using Microsoft.AspNetCore.Components;
using TopicCleanArchitecture.BlazorUI.Models.Categories;

namespace TopicCleanArchitecture.BlazorUI.Pages.Categories
{
    public partial class FormComponent
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public CategoryVM Category{ get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}