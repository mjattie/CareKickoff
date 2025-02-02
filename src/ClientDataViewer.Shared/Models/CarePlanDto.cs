namespace ClientDataViewer.Shared.Models;

public record CarePlanDto(string Id, string DisplayName, string ClientId, IEnumerable<GoalDto> Goals);