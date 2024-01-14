using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;
using TopicCleanArchitecture.BlazorUI;
using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Services;
using TopicCleanArchitecture.BlazorUI.Services.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IClient,Client>(Client=>Client.BaseAddress=new Uri("https://localhost:7131"));

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
