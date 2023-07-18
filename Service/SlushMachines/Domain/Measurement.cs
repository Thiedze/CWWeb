using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.SlushMachines.Domain;

[Table("Measurements")]
public class Measurement
{
    [Key] public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public List<MeasurementPoint> MeasurementPoints { get; set; }
}