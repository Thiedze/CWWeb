using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelfHosted.Controller.V1.SlushMachines.Domain;
using Service.SlushMachines;
using Service.SlushMachines.Domain;

namespace SelfHosted.Controller.V1.SlushMachines;

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