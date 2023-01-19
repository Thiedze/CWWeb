using Service.SlushMachines.Domain;
using Service.Users.Domain;

namespace Service.Database;

public class SqLiteService : IDatabaseService
{
    public void Insert(Measurement measurement)
    {
        using var dataContext = new DataContext();
        dataContext.Add(measurement);
        dataContext.SaveChangesAsync();
    }

    public T? Get<T>(int id)
    {
        using var dataContext = new DataContext();
        if (typeof(T) == typeof(User))
        {
            return (T) Convert.ChangeType(dataContext.Users?.FirstOrDefault(user => user.Id == id), typeof(T))!;
        }

        if (typeof(T) == typeof(Measurement))
        {
            return (T) Convert.ChangeType(dataContext.Measurements?.FirstOrDefault(measurement => measurement.Id == id),
                typeof(T))!;
        }

        return default;
    }
}