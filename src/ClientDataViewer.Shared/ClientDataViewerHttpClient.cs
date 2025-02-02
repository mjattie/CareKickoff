using System.Net.Http.Json;
using ClientDataViewer.Shared.Models;

namespace ClientDataViewer.Shared;

public class ClientDataViewerHttpClient
{
    private readonly HttpClient _httpClient;

    public ClientDataViewerHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ClientDetailDto?> GetClientDetails(string id)
    {
        var details = await _httpClient.GetAsync($"/api/clients/{id}");
        if (details.IsSuccessStatusCode) return await details.Content.ReadFromJsonAsync<ClientDetailDto>();
        return null;
    }

    public async Task<ClientDto[]?> GetAll()
    {
        var details = await _httpClient.GetAsync("/api/clients/");
        if (details.IsSuccessStatusCode) return await details.Content.ReadFromJsonAsync<ClientDto[]>();
        return null;
    }
}