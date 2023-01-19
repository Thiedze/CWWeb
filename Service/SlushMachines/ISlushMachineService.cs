using Service.SlushMachines.Domain;

namespace Service.SlushMachines;

public interface ISlushMachineService
{
    void AddMeasurement(Measurement measurement);
    List<SlushMachine>? GetSlushMachines();
}