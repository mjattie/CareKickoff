using ClientDataViewer.Data.CarePlan;
using ClientDataViewer.Data.Client;
using ClientDataViewer.Data.Report;
using Microsoft.AspNetCore.Components;

namespace ClientDataViewer.Client.Pages;

public partial class ClientDetails
{
    [Parameter] public string ClientId { get; set; }
    private readonly IClientRepository _clientRepository;
    private readonly IReportRepository _reportRepository;
    private readonly ICarePlanRepository _carePlanRepository;
    private Data.Client.Client _client;
    private CarePlan[] _carePlans;
    private Report[] _reports;

    public ClientDetails(IClientRepository clientRepository, IReportRepository reportRepository,
        ICarePlanRepository carePlanRepository)
    {
        _clientRepository = clientRepository;
        _reportRepository = reportRepository;
        _carePlanRepository = carePlanRepository;
    }

    protected override Task OnParametersSetAsync()
    {
        _client = _clientRepository.GetById(ClientId);
        _carePlans = _carePlanRepository.GetByClientId(ClientId);
        _reports = _reportRepository.GetByClientId(ClientId);
        return base.OnParametersSetAsync();
    }
}