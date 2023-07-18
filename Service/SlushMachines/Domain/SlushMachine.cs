using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.SlushMachines.Domain;

[Table("SlushMachines")]
public class SlushMachine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public SlushMachinePosition Position { get; set; }
    public SlushMachineStatus Status { get; set; }

    [NotMapped] public double Level { get; set; }
    public SlushMachineFlavor Flavor { get; set; }
}