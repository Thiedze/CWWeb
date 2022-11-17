using System.Data.Common;
using System.Data.SQLite;
using Service.SlushMachines.Domain;

namespace Service.Database;

public class SqLiteService : IDatabaseService
{
    public DbConnection CreateAndOpenConnection(string connectionString)
    {
        var connection = new SQLiteConnection(connectionString);
        connection.Open();
        return connection;
    }

    public void CreateDatabaseIfNotExist(string name, DbConnection connection)
    {
        if (!File.Exists(name))
        {
            File.Create(name);
        }
    }

    public void CreateTableIfNotExist(string name, DbConnection connection)
    {
        var statement = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{name}'";

        using var checkCommend = new SQLiteCommand(statement, (SQLiteConnection) connection);
        using var reader = checkCommend.ExecuteReader();

        if (!reader.Read())
        {
            statement =
                "CREATE TABLE measurement (\"timestamp\" TEXT, point_0 INTEGER, point_1 INTEGER, point_2 INTEGER, point_3 INTEGER)";
            using var createCommand = new SQLiteCommand(statement, (SQLiteConnection) connection);
            createCommand.ExecuteNonQuery();
        }
    }

    public void Insert(Measurement measurement, DbConnection connection)
    {
        var statement =
            $"INSERT INTO measurement VALUES(" +
            $"'{measurement.Timestamp}', " +
            $"{measurement.Points[0]}, " +
            $"{measurement.Points[1]}, " +
            $"{measurement.Points[2]}, " +
            $"{measurement.Points[3]})";

        using var checkCommend = new SQLiteCommand(statement, (SQLiteConnection) connection);
        checkCommend.ExecuteNonQuery();
    }

    public DbDataReader Get(string sql, DbConnection connection)
    {
        using var command = new SQLiteCommand(sql, (SQLiteConnection) connection);
        return command.ExecuteReader();
    }
}