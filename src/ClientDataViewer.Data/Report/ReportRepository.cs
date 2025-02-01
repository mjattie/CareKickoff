namespace ClientDataViewer.Data.Report;

public sealed class ReportRepository() : RepositoryWithJsonFileSource<Report>("reports.json"), IReportRepository
{
    public Report[] GetByClientId(string clientId)
    {
        return this.Entities.Where(x => x.ClientId == clientId).ToArray();
    }
}