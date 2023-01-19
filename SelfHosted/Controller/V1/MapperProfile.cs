using AutoMapper;
using SelfHosted.Controller.V1.Authorizations.Domain;
using SelfHosted.Controller.V1.SlushMachines.Domain;
using Service.Authorizations.Domain;
using Service.SlushMachines.Domain;

namespace SelfHosted.Controller.V1;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<MeasurementDto, Measurement>();
        CreateMap<SlushMachine, SlushMachineDto>();
        CreateMap<AuthenticateRequestDto, AuthenticateRequest>();
        CreateMap<AuthenticateResponse, AuthenticateResponseDto>();
    }
}