using ClientDataViewer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientDataViewer.Api;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService, IAuthorizationService authorizationService)
    {
        _clientService = clientService;
        _authorizationService = authorizationService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetClients()
    {
        if (User.Identity?.Name is null) return Forbid();

        return Ok(_clientService.GetUserClients(User.Identity.Name));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Details(string id)
    {
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, id, "ClientAccess");
        if (!authorizationResult.Succeeded)
            // should be Forbid, but this causes a redirect in the client side api caller
            return NotFound();

        return Ok(_clientService.GetClientDetails(id));
    }
}