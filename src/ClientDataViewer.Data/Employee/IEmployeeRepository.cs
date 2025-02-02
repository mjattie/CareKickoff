namespace ClientDataViewer.Data.Employee;

public interface IEmployeeRepository
{
    public Employee[] Get();
    string[] GetEmployeeUserIds(string? identityName);
    string[] GetEmployeeUserIdsByUserEmail(string userEmail);
}