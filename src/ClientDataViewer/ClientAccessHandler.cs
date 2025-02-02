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
        var email = context.User.Identity?.Name;
        if (email is null)
        {
            context.Fail();
            return;
        }
        
        var allowedClients = _employeeRepository.GetEmployeeUserIdsByUserEmail(email);
        
        if (allowedClients.Any(c => c == clientId))
        {
            context.Succeed(requirement);
            return;
        }

        context.Fail();
    }
}