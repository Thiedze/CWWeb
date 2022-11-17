using System.Data.Common;
using Service.Database;
using Service.SlushMachines.Domain;

namespace Service.SlushMachines;

public class SlushMachineService : ISlushMachineService
{
    private static string DatabaseFilename => "slush.db";
    private static string TableName => "measurement";
    private static string ConnectionString => @"URI=file:" + DatabaseFilename;
    private DbConnection Connection { get; set; }
    private IDatabaseService DatabaseService { get; }

    public SlushMachineService(IDatabaseService databaseService)
    {
        DatabaseService = databaseService;
        Connection = DatabaseService.CreateAndOpenConnection(ConnectionString);
        DatabaseService.CreateDatabaseIfNotExist(DatabaseFilename, Connection);
        DatabaseService.CreateTableIfNotExist("measurement", Connection);
    }

    public void AddMeasurement(Measurement measurement)
    {
        DatabaseService.Insert(measurement, Connection);
    }

    public List<SlushMachine> GetSlushMachines()
    {
        var slushMachines = new List<SlushMachine>();
        
        slushMachines.Add(new SlushMachine());
        slushMachines.Add(new SlushMachine());
        var reader =
            DatabaseService.Get(
                "SELECT point_0, point_1, point_2, point_3 FROM measurement order by \"timestamp\" DESC", Connection);


        reader.Read();
        slushMachines[0].Id = "left";
        slushMachines[0].Flavor = SlushMachineFlavor.Cola;
        slushMachines[0].Status = SlushMachineStatus.Freezing;
        slushMachines[0].Level = CalculateLevel(reader.GetInt32(0), reader.GetInt32(1));
        
        slushMachines[1].Id = "right";
        slushMachines[1].Flavor = SlushMachineFlavor.Strawberry;
        slushMachines[1].Status = SlushMachineStatus.Locked;
        slushMachines[1].Level = CalculateLevel(reader.GetInt32(2), reader.GetInt32(3));
        
        return slushMachines;
    }

    private static double CalculateLevel(int weightTop, int weightBottom)
    {
        double level;
        if (weightTop > weightBottom)
        {
            level = (double) weightBottom / weightTop * 100.0;
        }
        else
        {
            level = (double) weightTop / weightBottom * 100.0;
        }

        return Math.Round(level, 2);;
    }
}