namespace ClientDataViewer.Data.Employee;

public class EmployeeRepository() : RepositoryWithJsonFileSource<Employee>("employees.json"), IEmployeeRepository
{
    public string[] GetEmployeeUserIds(string? userName)
    {
        return Entities.SingleOrDefault(x => x.Name.Equals(userName, StringComparison.InvariantCultureIgnoreCase))
            ?.AuthorizedClients ?? [];
    }

    public string[] GetEmployeeUserIdsByUserEmail(string userEmail)
    {
        //TODO user should have some Id instead of authentication on first part of user email :D
        return GetEmployeeUserIds(userEmail.Split('@')[0]);
    }
}