using Microsoft.Extensions.DependencyInjection;

namespace ClientDataViewer.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services, string baseAddress)
    {
        // services.AddTransient<BaseAddressAuthorizationMessageHandler>();
        services.AddTransient<CookieHandler>();
        services.AddHttpClient<ClientDataViewerHttpClient>(configureClient =>
                configureClient.BaseAddress = new Uri(baseAddress))
            // .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            .AddHttpMessageHandler<CookieHandler>();

        return services;
    }
}