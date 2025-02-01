namespace ClientDataViewer.Data.CarePlan;

public record CarePlan(string Id, string DisplayName, string ClientId, Goal[] Goals);