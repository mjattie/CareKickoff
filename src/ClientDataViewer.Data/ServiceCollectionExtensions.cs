using Microsoft.Extensions.DependencyInjection;

namespace ClientDataViewer.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IClientRepository, ClientRepository>();

        return services;
    }
}