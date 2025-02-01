using ClientDataViewer.Data.Client;

namespace ClientDataViewer.Client.Pages;

public partial class Clients
{
    private readonly IClientRepository _clientRepository;
    private Data.Client.Client[] _clients = [];

    public Clients(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    protected override void OnInitialized()
    {
        _clients = _clientRepository.Get();
    }
}