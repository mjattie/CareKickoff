using ClientDataViewer.Shared;
using ClientDataViewer.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClientDataViewer.Client.Pages;

public partial class ClientDetails
{
    private readonly ClientDataViewerHttpClient _httpClient;
    private CarePlanDto[] _carePlans = [];
    private ClientDto _client;
    private bool _notFound;
    private ReportDto[] _reports = [];

    public ClientDetails(ClientDataViewerHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [Parameter] public string ClientId { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var clientDetails = await _httpClient.GetClientDetails(ClientId);
        if (clientDetails is null)
        {
            // should be redirect to not found page
            _notFound = true;
            return;
        }

        _client = clientDetails.Client;
        _carePlans = clientDetails.CarePlans.ToArray();
        _reports = clientDetails.Reports.ToArray();
    }
}