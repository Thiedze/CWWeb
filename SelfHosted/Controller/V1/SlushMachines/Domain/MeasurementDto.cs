using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SelfHosted.Controller.V1.SlushMachines.Domain;

public class MeasurementDto
{
    [JsonPropertyName("timestamp")] public string Timestamp { get; set; }
    [JsonPropertyName("points")] public List<int> Points { get; set; }
}