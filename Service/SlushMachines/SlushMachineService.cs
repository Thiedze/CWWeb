using Service.Database;
using Service.SlushMachines.Domain;

namespace Service.SlushMachines;

public class SlushMachineService : ISlushMachineService
{
    public void AddMeasurement(Measurement measurement)
    {
        using var dataContext = new DataContext();
        dataContext.Measurements?.Add(measurement);
        dataContext.SaveChangesAsync();
    }

    public List<SlushMachine>? GetSlushMachines()
    {
        using var dataContext = new DataContext();
        var measurement = dataContext.Measurements?.OrderBy(entry => entry.Timestamp).FirstOrDefault();
        var slushMachines = dataContext.SlushMachines?.ToList();

        if (measurement != null && slushMachines != null)
        {
            slushMachines[0].Level = CalculateLevel(measurement.MeasurementPoints[0].Value,
                measurement.MeasurementPoints[1].Value);
            slushMachines[1].Level = CalculateLevel(measurement.MeasurementPoints[2].Value,
                measurement.MeasurementPoints[3].Value);
        }

        return slushMachines;
    }

    private static double CalculateLevel(double weightTop, double weightBottom)
    {
        double level;
        if (weightTop > weightBottom)
        {
            level = weightBottom / weightTop * 100.0;
        }
        else
        {
            level = weightTop / weightBottom * 100.0;
        }

        return Math.Round(level, 2);
    }
}