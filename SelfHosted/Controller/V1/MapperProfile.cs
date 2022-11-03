using AutoMapper;
using SelfHosted.Controller.V1.SlushMachine.Domain;
using Service.SlushMachine.Domain;

namespace SelfHosted.Controller. V1;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<MeasurementDto, Measurement>();
    }
}