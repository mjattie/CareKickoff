using ClientDataViewer.Data.CarePlan;
using ClientDataViewer.Data.Client;
using ClientDataViewer.Data.Employee;
using ClientDataViewer.Data.Report;
using Microsoft.Extensions.DependencyInjection;

namespace ClientDataViewer.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICarePlanRepository, CarePlanRepository>();
        services.AddSingleton<IClientRepository, ClientRepository>();
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IReportRepository, ReportRepository>();

        return services;
    }
}