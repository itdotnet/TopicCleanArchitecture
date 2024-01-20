using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Providers;

namespace TopicCleanArchitecture.BlazorUI.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
    }
    
    protected void GoToLogin()
    {
        NavigationManager.NavigateTo("login/");
    }

    protected void GoToRegister()
    {
        NavigationManager.NavigateTo("register/");
    }

    protected async void Logout()
    {
        await AuthenticationService.Logout();
    }
}