using System.Net.Http.Json;
using ClientDataViewer.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

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
        if (details.IsSuccessStatusCode)
        {
            return await details.Content.ReadFromJsonAsync<ClientDetailDto>();
        }
        // TODO handle other status codes
        return null;
    }
    
    public async Task<ClientDto[]?> GetAll()
    {
        var details = await _httpClient.GetAsync("/api/clients/");
        if (details.IsSuccessStatusCode)
        {
            return await details.Content.ReadFromJsonAsync<ClientDto[]>();
        }
        // TODO handle other status codes
        return null;
    }
}