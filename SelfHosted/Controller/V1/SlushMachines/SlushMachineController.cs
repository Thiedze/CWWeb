using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelfHosted.Controller.V1.SlushMachines.Domain;
using Service.SlushMachines;
using Service.SlushMachines.Domain;

namespace SelfHosted.Controller.V1.SlushMachines;

[ApiController]
public class SlushMachineController : ControllerBase
{
    public SlushMachineController(ISlushMachineService slushMachineService, IMapper mapper)
    {
        SlushMachineService = slushMachineService;
        Mapper = mapper;
    }

    private IMapper Mapper { get; }
    private ISlushMachineService SlushMachineService { get; }

    [HttpPost]
    [Route(UrlConfiguration.V1ApiUrl + "/slush_machines/measurements")]
    public ObjectResult AddMeasurement()
    {
        var measurementDto = RequestHandler.GetObject<MeasurementDto>(Request);

        SlushMachineService.AddMeasurement(Mapper.Map<MeasurementDto, Measurement>(measurementDto));
        return new OkObjectResult("");
    }

    [HttpGet]
    [Route(UrlConfiguration.V1ApiUrl + "/slush_machines")]
    public ObjectResult GetSlushMachines()
    {
        var slushMachinesDto =
            Mapper.Map<List<SlushMachine>, List<SlushMachineDto>>(SlushMachineService.GetSlushMachines());
        return new ObjectResult(slushMachinesDto);
    }
}