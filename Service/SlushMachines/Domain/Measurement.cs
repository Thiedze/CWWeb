namespace Service.SlushMachines.Domain;

public class Measurement
{
    public DateTime Timestamp { get; set; }
    public List<int> Points { get; set; } = new();
}