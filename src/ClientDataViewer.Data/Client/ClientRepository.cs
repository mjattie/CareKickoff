namespace ClientDataViewer.Data.Client;

public sealed class ClientRepository() : RepositoryWithJsonFileSource<Client>("clients.json"), IClientRepository;