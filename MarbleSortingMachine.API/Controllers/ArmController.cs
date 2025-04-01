using MarbleSortingMachine.Domain.Common;
using MarbleSortingMachine.Domain.Containers;
using MarbleSortingMachine.Domain.Marble;
using MarbleSortingMachine.Infrastructure.Interfaces.Arm;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MarbleSortingMachineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmController : ControllerBase
    {
        private readonly IArmService _armService;
        private readonly IContainerGenerator _containerGenerator;
        private readonly IContainerService _containerService;

        public ArmController(IArmService armService, IContainerGenerator containerGenerator, IContainerService containerService)
        {
            _armService = armService;
            _containerGenerator = containerGenerator;
            _containerService = containerService;
        }

        [HttpGet("Sort")]
        [ActionName("Sort")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ContainerBase>))]
        public ActionResult Sort()
        {
            Log.Information("Sort is called");

            long marbleCount = 1000;
            var container = new BigContainer();
            var marble = new Marble();

            var bigContainer = _containerGenerator.GenerateContainer(container, marble);

            _containerService.Fill(bigContainer, marbleCount);

            var containers = _armService.Sort(bigContainer);
            return Ok(containers);
        }

        [HttpGet("SortByColor")]
        [ActionName("SortByColor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ContainerBase>))]
        public ActionResult SortByColor(Colors color)
        {
            long marbleCount = 1000;
            var container = new BigContainer();
            var marble = new Marble();

            var bigContainer = _containerGenerator.GenerateContainer(container, marble);

            _containerService.Fill(bigContainer, marbleCount);

            var containers = _armService.Sort(bigContainer, color);
            return Ok(containers);
        }
    }
}
