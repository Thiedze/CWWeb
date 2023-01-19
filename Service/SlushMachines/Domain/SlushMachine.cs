using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.SlushMachines.Domain;

public class SlushMachine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string? Position { get; set; }
    public SlushMachineStatus? Status { get; set; }
    public double? Level { get; set; }
    public SlushMachineFlavor? Flavor { get; set; }
}