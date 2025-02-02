namespace ClientDataViewer.Shared.Models;

public record ClientDetailDto(ClientDto Client, IEnumerable<CarePlanDto> CarePlans, IEnumerable<ReportDto> Reports);