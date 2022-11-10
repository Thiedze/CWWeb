using System.Data.Common;
using Service.SlushMachine.Domain;

namespace Service.Database;

public interface IDatabaseService
{
    public DbConnection CreateAndOpenConnection(string connectionString);
    public void CreateDatabaseIfNotExist(string name, DbConnection connection);
    public void CreateTableIfNotExist(string name, DbConnection connection);
    public void Insert(Measurement measurement, DbConnection connection);
}