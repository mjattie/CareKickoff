using ClientDataViewer.Data.CarePlan;
using ClientDataViewer.Data.Client;
using ClientDataViewer.Data.Employee;
using ClientDataViewer.Data.Report;
using ClientDataViewer.Domain.Translators;
using ClientDataViewer.Shared.Models;

namespace ClientDataViewer.Domain;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IReportRepository _reportRepository;
    private readonly ICarePlanRepository _carePlanRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public ClientService(IClientRepository clientRepository, IReportRepository reportRepository, ICarePlanRepository carePlanRepository, IEmployeeRepository employeeRepository)
    {
        _clientRepository = clientRepository;
        _reportRepository = reportRepository;
        _carePlanRepository = carePlanRepository;
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<ClientDto> GetUserClients(string userEmail)
    {
        var userClientIds = _employeeRepository.GetEmployeeUserIdsByUserEmail(userEmail);
        return _clientRepository.GetByClientIds(userClientIds).ToDto();
    }

    public ClientDetailDto GetClientDetails(string clientId)
    {
        var client = _clientRepository.GetById(clientId);
        var reports = _reportRepository.GetByClientId(clientId);
        var carePlans = _carePlanRepository.GetByClientId(clientId);
        return new ClientDetailDto(client.ToDto(), carePlans.ToDto(), reports.ToDto());
    }
    
    public IEnumerable<ClientDto> GetClients()
    {
        return _clientRepository.Get().ToDto();
    }
}

public interface IClientService
{
    IEnumerable<ClientDto> GetClients();
    IEnumerable<ClientDto> GetUserClients(string userEmail);
    ClientDetailDto GetClientDetails(string clientId);
}