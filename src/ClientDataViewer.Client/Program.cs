using ClientDataViewer.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddSharedServices(builder.HostEnvironment.BaseAddress);
builder.Services.AddHttpContextAccessor();

await builder.Build().RunAsync();