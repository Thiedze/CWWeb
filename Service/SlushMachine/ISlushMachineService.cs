using Service.SlushMachine.Domain;

namespace Service.SlushMachine;

public interface ISlushMachineService
{
    void AddMeasurement(Measurement measurement);
}