namespace Service.SlushMachines.Domain;

public class SlushMachine
{
    public string? Id { get; set; }
    public SlushMachineStatus? Status { get; set; }
    public double? Level { get; set; }
    public SlushMachineFlavor? Flavor { get; set; }
}