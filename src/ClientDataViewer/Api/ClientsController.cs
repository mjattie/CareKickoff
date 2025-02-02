using ClientDataViewer.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientDataViewer.Api;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : Controller
{
    private readonly IClientService _clientService;
    private readonly IAuthorizationService _authorizationService;

    public ClientsController(IClientService clientService, IAuthorizationService authorizationService)
    {
        _clientService = clientService;
        _authorizationService = authorizationService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetClients()
    {
        if (User.Identity?.Name is null)
        {
            return Forbid();
        }
        
        return Ok(_clientService.GetUserClients(User.Identity.Name));
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Details(string id)
    {
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, id, "ClientAccess");
        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }
        
        return Ok(_clientService.GetClientDetails(id));
    }
}