using ClientDataViewer.Shared;
using ClientDataViewer.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClientDataViewer.Client.Pages;

public partial class ClientDetails
{
    private readonly ClientDataViewerHttpClient _httpClient;
    [Parameter] public string ClientId { get; set; }
    private ClientDto _client;
    private CarePlanDto[] _carePlans = [];
    private ReportDto[] _reports = [];

    public ClientDetails(ClientDataViewerHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected override async Task OnParametersSetAsync()
    {
        var clientDetails = await _httpClient.GetClientDetails(ClientId);
        _client = clientDetails.Client;
        _carePlans = clientDetails.CarePlans.ToArray();
        _reports = clientDetails.Reports.ToArray();
    }
}