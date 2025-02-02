using ClientDataViewer.Data.CarePlan;
using ClientDataViewer.Data.Client;
using ClientDataViewer.Data.Report;
using ClientDataViewer.Shared.Models;

namespace ClientDataViewer.Domain.Translators;

public static class ModelTranslations
{
    public static CarePlanDto ToDto(this CarePlan carePlan)
    {
        return new CarePlanDto(carePlan.Id, carePlan.DisplayName, carePlan.ClientId, carePlan.Goals.ToDto());
    }

    public static IEnumerable<CarePlanDto> ToDto(this IEnumerable<CarePlan> carePlans)
    {
        return carePlans.Select(ToDto);
    }

    public static ClientDto ToDto(this Client client)
    {
        return new ClientDto(client.FirstName, client.LastName, client.BirthDate, ToGender(client.Gender),
            client.NativeId);
    }

    public static IEnumerable<ClientDto> ToDto(this IEnumerable<Client> clients)
    {
        return clients.Select(ToDto);
    }

    public static ReportDto ToDto(this Report report)
    {
        return new ReportDto(report.Subject, report.Text, report.HasPriority, report.CarePlanGoalId, report.ClientId,
            report.CreatedBy, report.CreatedAt);
    }

    public static IEnumerable<ReportDto> ToDto(this IEnumerable<Report> reports)
    {
        return reports.Select(ToDto);
    }

    public static GoalDto ToDto(this Goal goal)
    {
        return new GoalDto(goal.DisplayName, goal.GoalId);
    }

    public static IEnumerable<GoalDto> ToDto(this IEnumerable<Goal> goals)
    {
        return goals.Select(ToDto);
    }

    public static Gender ToGender(string gender)
    {
        return gender switch
        {
            "male" => Gender.Male,
            "female" => Gender.Female,
            _ => Gender.Other
        };
    }
}