namespace ClientDataViewer.Data.Entities;

public record CarePlan(string Id, string DisplayName, string ClientId, List<Goal> Goals);