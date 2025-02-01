namespace ClientDataViewer.Data.CarePlan;

public sealed class CarePlanRepository() : RepositoryWithJsonFileSource<CarePlan>("careplans.json"), ICarePlanRepository;