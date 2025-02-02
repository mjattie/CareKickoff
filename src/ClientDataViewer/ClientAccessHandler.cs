using ClientDataViewer.Data.Employee;
using Microsoft.AspNetCore.Authorization;

namespace ClientDataViewer;

public class ClientAccessHandler : AuthorizationHandler<ClientAccessRequirement, string>
{
    private readonly IEmployeeRepository _employeeRepository;

    public ClientAccessHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context, ClientAccessRequirement requirement, string clientId)
    {
        var firstPartOfEmail = context.User.Identity?.Name;
        if (firstPartOfEmail is null)
        {
            context.Fail();
            return;
        }
        
        var allowedClients = _employeeRepository.GetEmployeeUserIdsByUserEmail(firstPartOfEmail);
        
        if (allowedClients.Any(c => c == clientId))
        {
            context.Succeed(requirement);
        }
    }
}