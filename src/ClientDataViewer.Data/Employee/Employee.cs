namespace ClientDataViewer.Data.Employee;

public record Employee(string Name, string EmployeeId, List<string> AuthorizedClients);