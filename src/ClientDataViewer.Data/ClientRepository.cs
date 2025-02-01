using System.Reflection;
using System.Text.Json;
using ClientDataViewer.Data.Entities;

namespace ClientDataViewer.Data;

public class ClientRepository : IClientRepository
{
    private Client[] Clients { get; set; }
    public ClientRepository()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("ClientDataViewer.Data.Data.clients.json");
        if (stream is null)
        {
            throw new FileNotFoundException("Clients.json not found");
        }
        Clients = JsonSerializer.Deserialize<Client[]>(stream) ?? [];
    }

    public Client[] Get()
    {
        return Clients;
    }
}

public interface IClientRepository
{
    public Client[] Get();
}