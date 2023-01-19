using Service.SlushMachines.Domain;

namespace Service.Database;

public interface IDatabaseService
{
    public void Insert(Measurement measurement);
    T? Get<T>(int id);
}