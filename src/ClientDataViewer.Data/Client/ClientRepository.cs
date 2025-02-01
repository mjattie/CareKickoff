namespace ClientDataViewer.Data.Client;

public sealed class ClientRepository() : RepositoryWithJsonFileSource<Client>("clients.json"), IClientRepository
{
    public Client GetById(string clientId)
    {
        return Entities.Single(x => x.NativeId == clientId);
    }
}