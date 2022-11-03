using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelfHosted.Controller.V1.SlushMachine.Domain;
using Service.SlushMachine;
using Service.SlushMachine.Domain;

namespace SelfHosted.Controller.V1.SlushMachine;

public class SlushMachineController : ControllerBase
{
    private IMapper Mapper { get; }
    private ISlushMachineService SlushMachineService { get; }

    public SlushMachineController(ISlushMachineService slushMachineService, IMapper mapper)
    {
        SlushMachineService = slushMachineService;
        Mapper = mapper;
    }

    [HttpPost]
    [Route(UrlConfiguration.V1ApiUrl + "/measurements")]
    public ObjectResult AddMeasurement()
    {
        var measurementDto = RequestHandler.GetObject<MeasurementDto>(Request);

        SlushMachineService.AddMeasurement(Mapper.Map<MeasurementDto, Measurement>(measurementDto));
        return new OkObjectResult("");
    }
}