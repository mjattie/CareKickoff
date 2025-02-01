namespace ClientDataViewer.Data.CarePlan;

public interface ICarePlanRepository
{
    public CarePlan[] Get();
    CarePlan[] GetByClientId(string clientId);
}