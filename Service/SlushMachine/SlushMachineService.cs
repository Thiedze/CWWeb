using System.Data.Common;
using System.Data.SQLite;
using Service.Database;
using Service.SlushMachine.Domain;

namespace Service.SlushMachine;

public class SlushMachineService: ISlushMachineService
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
}