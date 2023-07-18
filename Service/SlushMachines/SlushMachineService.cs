using System.Collections.Generic;
using System.Linq;
using Service.Database;
using Service.SlushMachines.Domain;

namespace Service.SlushMachines;

public class SlushMachineService : ISlushMachineService
{
    private List<double> Full { get; } = new() {396, 390};

    private List<double> Empty { get; } = new() {69, 66};

    public void AddMeasurement(Measurement measurement)
    {
        using var dataContext = new DataContext();
        dataContext.Measurements?.Add(measurement);
        dataContext.SaveChangesAsync().Wait();
    }

    public List<SlushMachine> GetSlushMachines()
    {
        using var dataContext = new DataContext();
        var measurement = dataContext.Measurements?.OrderBy(entry => entry.Timestamp).Reverse().First();
        var slushMachines = dataContext.SlushMachines?.ToList();

        if (measurement != null && slushMachines != null)
        {
            dataContext.Entry(measurement).Collection(entry => entry.MeasurementPoints).Load();
            var measurementPoints = measurement.MeasurementPoints;

            CalculateLevel(slushMachines.Find(slushMachine => SlushMachinePosition.Left.Equals(slushMachine.Position)),
                measurementPoints);
            CalculateLevel(slushMachines.Find(slushMachine => SlushMachinePosition.Right.Equals(slushMachine.Position)),
                measurementPoints);
        }

        return slushMachines;
    }

    private void CalculateLevel(SlushMachine slushMachine, List<MeasurementPoint> measurementPoints)
    {
        var sumLeft = measurementPoints[0].Value + measurementPoints[1].Value;
        var sumRight = measurementPoints[2].Value + measurementPoints[3].Value;

        if (SlushMachinePosition.Left.Equals(slushMachine.Position))
        {
            if (sumLeft > sumRight)
            {
                slushMachine.Level = sumLeft / (Full[0] - Empty[0]);
            }
            else
            {
                slushMachine.Level = (sumLeft - Empty[0]) / Full[0];
            }
        }
        else if (SlushMachinePosition.Right.Equals(slushMachine.Position))
        {
            if (sumRight > sumLeft)
            {
                slushMachine.Level = sumRight / (Full[0] - Empty[0]);
            }
            else
            {
                slushMachine.Level = (sumRight - Empty[0]) / Full[0];
            }
        }
    }
}