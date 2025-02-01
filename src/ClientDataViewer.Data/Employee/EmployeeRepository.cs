namespace ClientDataViewer.Data.Employee;

public sealed class EmployeeRepository() : RepositoryWithJsonFileSource<Employee>("employees.json"), IEmployeeRepository;