namespace ClientDataViewer.Data.Client;

public interface IClientRepository
{
    public Client[] Get();
    Client GetById(string clientId);
}