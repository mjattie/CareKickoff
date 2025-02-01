namespace ClientDataViewer.Data.CarePlan;

public sealed class CarePlanRepository() : RepositoryWithJsonFileSource<CarePlan>("careplans.json"), ICarePlanRepository
{
    public CarePlan[] GetByClientId(string clientId)
    {
        return Entities.Where(x => x.ClientId == clientId).ToArray();
    }
}