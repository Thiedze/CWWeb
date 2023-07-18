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
        CreateMap<MeasurementDto, Measurement>()
            .ForMember(destination => destination.MeasurementPoints, option => option.MapFrom(source => source.Points));
        CreateMap<int, MeasurementPoint>()
            .ForMember(destination => destination.Value, option => option.MapFrom(source => source));
        CreateMap<SlushMachine, SlushMachineDto>();
        CreateMap<AuthenticateRequestDto, AuthenticateRequest>();
        CreateMap<AuthenticateResponse, AuthenticateResponseDto>();
    }
}