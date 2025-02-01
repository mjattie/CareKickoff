namespace ClientDataViewer.Data.Report;

public interface IReportRepository
{
    public Report[] Get();
    Report[] GetByClientId(string clientId);
}