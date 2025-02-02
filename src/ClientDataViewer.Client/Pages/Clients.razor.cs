using ClientDataViewer.Shared;
using ClientDataViewer.Shared.Models;

namespace ClientDataViewer.Client.Pages;

public partial class Clients
{
    private readonly ClientDataViewerHttpClient _httpClient;
    private IEnumerable<ClientDto> _clients = [];

    public Clients(ClientDataViewerHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected override async Task OnInitializedAsync()
    {
        _clients = await _httpClient.GetAll();
    }
}