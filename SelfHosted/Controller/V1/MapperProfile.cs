using AutoMapper;
using SelfHosted.Controller.V1.SlushMachines.Domain;
using Service.SlushMachines.Domain;

namespace SelfHosted.Controller.V1;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<MeasurementDto, Measurement>();
        CreateMap<SlushMachine, SlushMachineDto>();
    }
}