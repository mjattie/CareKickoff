using ClientDataViewer.Shared.Models;

namespace ClientDataViewer.Data.Client;

public sealed class ClientRepository() : RepositoryWithJsonFileSource<Client>("clients.json"), IClientRepository
{
    public Client GetById(string clientId)
    {
        return Entities.Single(x => x.NativeId == clientId);
    }

    public IEnumerable<Client> GetByClientIds(string[] clientIds)
    {
        return Entities.Where(x => clientIds.Contains(x.NativeId));
    }
}