using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.SlushMachines.Domain;

[Table("MeasurementPoints")]
public class MeasurementPoint
{
    [Key] public int Id { get; set; }
    public double Value { get; set; }
}