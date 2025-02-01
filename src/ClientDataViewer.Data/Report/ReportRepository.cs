namespace ClientDataViewer.Data.Report;

public sealed class ReportRepository() : RepositoryWithJsonFileSource<Report>("reports.json"), IReportRepository;