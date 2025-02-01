namespace ClientDataViewer.Data.Entities;

public record Employee(string Name, string EmployeeId, List<string> AuthorizedClients);