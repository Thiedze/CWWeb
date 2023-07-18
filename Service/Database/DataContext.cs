using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Service.SlushMachines.Domain;
using Service.Users.Domain;

namespace Service.Database;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<MeasurementPoint> MeasurementPoints { get; set; }
    public DbSet<SlushMachine> SlushMachines { get; set; }
    private static string DatabaseFilename => "cwweb.db";
    private string ConnectionString { get; }

    public DataContext()
    {
        var path = Directory.GetParent(Environment.CurrentDirectory)?.FullName;
        Console.WriteLine(path);
        ConnectionString = $"Data Source={Path.Join(path, DatabaseFilename)}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(ConnectionString);
    }
}