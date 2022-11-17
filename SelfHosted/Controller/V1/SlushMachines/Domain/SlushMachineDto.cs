using System.Text.Json.Serialization;
using Service.SlushMachines.Domain;

namespace SelfHosted.Controller.V1.SlushMachines.Domain;

public class SlushMachineDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("level")]
    public double Level { get; set; }
    
    [JsonPropertyName("flavor")]
    public string Flavor { get; set; }
}